using System;
using System.Collections.Generic;
using System.Linq;
using BepInEx.Configuration;
using Hazel;
using Reactor.Utilities.Extensions;
using UnityEngine;

namespace TownOfUs.CustomOption
{
    public class CustomOption
    {
        public enum CustomOptionType {
            General,
            Crewmate,
            Neutral,
            Impostor,
            Modifier,
        }

        public enum ValueType {
            String,
            Toggle,
            Number,
            Header
        }

        public static List<CustomOption> options = new();
        public static int preset = 0;
        public static ConfigEntry<string> baseSettings;

        public int id;
        public string name;
        public object[] selections;

        public float defaultSelection;
        public ConfigEntry<float> entry;
        public float selection;
        public OptionBehaviour optionBehaviour;
        public CustomOption parent;
        public bool isHeader;
        public CustomOptionType type;
        public Func<float, string> Format;
        public ValueType valueType;
        public GameMode GameMode;
        public bool IsHidden;

        public float Min { get; set; }
        public float Max { get; set; }
        public float Increment { get; set; }

        // Option creation
        public CustomOption(int id, CustomOptionType type, string name, ValueType valueType, object[] selections, object defaultValue, Func<float, string> format, CustomOption parent, bool isHeader, bool IsHidden, GameMode GameMode) {
            this.id = id;
            this.name = parent == null ? name : name;
            this.selections = selections;
            this.parent = parent;
            this.isHeader = isHeader;
            this.type = type;
            this.valueType = valueType;
            this.GameMode = GameMode;
            this.IsHidden = IsHidden;
            Format = format ?? (obj => $"{obj}");

            switch (valueType) {
                case ValueType.String:
                    int sIndex = Array.IndexOf(selections, defaultValue);
                    this.defaultSelection = sIndex >= 0 ? sIndex : 0;
                    break;
                case ValueType.Number:
                    defaultSelection = (float)defaultValue;
                    break;
                case ValueType.Toggle:
                    int tIndex = Array.IndexOf(selections, defaultValue);
                    this.defaultSelection = tIndex >= 0 ? tIndex : 0;
                    break;
                case ValueType.Header:
                    defaultSelection = 1f;
                    break;
            }
            selection = defaultSelection;
            if (id != 0) {
                entry = TownOfUs.Instance.Config.Bind($"Preset{preset}", id.ToString(), defaultSelection);
                selection = entry.Value;
            }
            if (valueType == ValueType.Header) selection = defaultSelection;
            options.Add(this);
        }

        public static CustomOption CreateString(int id, CustomOptionType type, string name, string[] selections, CustomOption parent = null, bool isHeader = false, bool IsHidden = false, GameMode GameMode = GameMode.All) {
            Func<float, string> format = (float value) => selections[Math.Clamp((int)value, 0, selections.Length - 1)];
            return new CustomOption(id, type, name, ValueType.String, selections, "", format, parent, isHeader, IsHidden, GameMode);
        }

        public static CustomOption CreateNumber(int id, CustomOptionType type, string name, float defaultValue, float min, float max, float step, Func<float, string> format = null, CustomOption parent = null, bool isHeader = false, bool IsHidden = false, GameMode GameMode = GameMode.All) {
            List<object> selections = new();
            for (float s = min; s <= max; s += step)
                selections.Add(s);
            return new CustomOption(id, type, name, ValueType.Number, selections.ToArray(), defaultValue, format, parent, isHeader, IsHidden, GameMode) {
                Min = min, Max = max, Increment = step
            };
        }

        public static CustomOption CreateToggle(int id, CustomOptionType type, string name, bool defaultValue, CustomOption parent = null, bool isHeader = false, bool IsHidden = false, GameMode GameMode = GameMode.All) {
            Func<float, string> format = (float val) => (int)val <= 0 ? "Off" : "On";
            return new CustomOption(id, type, name, ValueType.Toggle, new string[] { "Off", "On" }, defaultValue ? "On" : "Off", format, parent, isHeader, IsHidden, GameMode);
        }

        public static CustomOption CreateHeader(int id, CustomOptionType type, string name, bool IsHidden = false, GameMode GameMode = GameMode.All) {
            return new CustomOption(id, type, name, ValueType.Header, Array.Empty<string>(), 1, null, null, true, IsHidden, GameMode);
        }

        public static string cs(Color c, string s) {
            return $"<color=#{UnityExtensions.ToHtmlStringRGBA(c)}>{s}</color>";
        }

        public bool IsHiddenOn(GameMode mode) {
            return IsHidden || (GameMode != GameMode.All && GameMode != mode);
        }

        // Static behaviour
        public static void SwitchPreset(int newPreset) {
            SaveBaseOptions();
            preset = newPreset;
            baseSettings = TownOfUs.Instance.Config.Bind($"Preset{preset}", "GameOptions", "");
            LoadBaseOptions();
            foreach (CustomOption option in options) {
                if (option.id == 0) continue;

                option.entry = TownOfUs.Instance.Config.Bind($"Preset{preset}", option.id.ToString(), option.defaultSelection);
                option.selection = option.entry.Value;

                if (option.optionBehaviour != null && option.optionBehaviour is StringOption stringOption) {
                    int oldValue = (stringOption.Value = option);
                    stringOption.oldValue = oldValue;
                    stringOption.ValueText.text = option;
                    continue;
                }
                if (option.optionBehaviour != null && option.optionBehaviour is ToggleOption toggleOption) {
                    toggleOption.CheckMark.enabled = option;
                    continue;
                }
                if (option.optionBehaviour != null && option.optionBehaviour is NumberOption numberOption) {
                    numberOption.ValidRange = new FloatRange(option.Min, option.Max);
                    numberOption.Increment = option.Increment;
                    float oldValue2 = (numberOption.Value = option);
                    numberOption.oldValue = oldValue2;
                    numberOption.ValueText.text = option;
                }
            }
        }

        public static void SaveBaseOptions() {
            baseSettings.Value = Convert.ToBase64String(GameOptionsManager.Instance.gameOptionsFactory.ToBytes(GameManager.Instance.LogicOptions.currentGameOptions));
        }

        public static void LoadBaseOptions() {
            string optionsString = baseSettings.Value;
            if (optionsString == "") return;
            GameOptionsManager.Instance.GameHostOptions = GameOptionsManager.Instance.gameOptionsFactory.FromBytes(Convert.FromBase64String(optionsString));
            GameOptionsManager.Instance.CurrentGameOptions = GameOptionsManager.Instance.GameHostOptions;
            GameManager.Instance.LogicOptions.SetGameOptions(GameOptionsManager.Instance.CurrentGameOptions);
            GameManager.Instance.LogicOptions.SyncOptions();
        }

        public static void SendRpc(CustomOption option = null) {
            if (PlayerControl.AllPlayerControls.Count <= 1 || AmongUsClient.Instance!.AmHost == false && PlayerControl.LocalPlayer == null) return;
            List<CustomOption> optionsList = option == null ? new List<CustomOption>(options.Where(x => x.valueType != ValueType.Header)) : new List<CustomOption> { option };
            while (optionsList.Any()) {
                byte amount = (byte)Math.Min(optionsList.Count, 200);
                MessageWriter writer = AmongUsClient.Instance!.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SyncCustomSettings, SendOption.Reliable, -1);
                writer.Write(amount);
                for (int i = 0; i < amount; i++) {
                    CustomOption item = optionsList[0];
                    optionsList.RemoveAt(0);
                    writer.WritePacked((uint) item.id);
                    writer.Write(item.selection);
                }
                AmongUsClient.Instance.FinishRpcImmediately(writer);
            }
        }

        public static void ReceiveRpc(byte numberOfOptions, MessageReader reader) {
            try {
                for (int i = 0; i < numberOfOptions; i++) {
                    uint optionId = reader.ReadPackedUInt32();
                    float selection = reader.ReadSingle();
                    CustomOption option = options.First(option => option.id == (int)optionId);
                    option.Set(selection);
                }
            } catch (Exception e) {
                TownOfUs.Logger.LogError("Error while deserializing options: " + e.Message);
            }
        }

        // Getter
        public int Get() => (int)selection;
        public static implicit operator int(CustomOption option) => option.Get();

        public bool GetBool() => Get() > 0;
        public static implicit operator bool(CustomOption option) => option.GetBool();

        public float GetFloat() => selection;
        public static implicit operator float(CustomOption option) => option.GetFloat();

        public override string ToString() => Format(selection);
        public static implicit operator string(CustomOption option) => option.ToString();

        // Option changes
        public void Set(float newSelection, bool SendRpc = true) {
            selection = newSelection;
            if (AmongUsClient.Instance != null && AmongUsClient.Instance.AmHost && PlayerControl.LocalPlayer) {
                if (id == 0) SwitchPreset(Get());
                else if (entry != null) entry.Value = selection;
            }
            if (optionBehaviour != null && AmongUsClient.Instance.AmHost && PlayerControl.LocalPlayer && SendRpc) {
                if (id == 0) CustomOption.SendRpc();
                else CustomOption.SendRpc(this);
            }
            if (optionBehaviour == null) return;
            if (optionBehaviour != null && optionBehaviour is StringOption stringOption) {
                int oldValue = (stringOption.Value = Get());
                stringOption.oldValue = oldValue;
                stringOption.ValueText.text = ToString();
                return;
            }
            if (optionBehaviour != null && optionBehaviour is ToggleOption toggleOption) {
                toggleOption.CheckMark.enabled = GetBool();
                return;
            }
            if (optionBehaviour != null && optionBehaviour is NumberOption numberOption) {
                float oldValue = (numberOption.Value = GetFloat());
                numberOption.oldValue = oldValue;
                numberOption.ValueText.text = ToString();
            }
        }

        public void Toggle() { Set(1 - Get()); }
        public void Increase() {
            if (valueType == ValueType.String) {
                if (Get() >= selections.Length - 1) Set(0);
                else Set(Get() + 1);
            }
            else if (valueType == ValueType.Number) {
                float increment = Increment > 1f && Input.GetKeyInt(KeyCode.LeftShift) ? Increment / 2 : Increment;
                if (GetFloat() + increment > Max + 0.001f) Set(Min);
                else Set(GetFloat() + increment);
            }
        }
        public void Decrease() {
            if (valueType == ValueType.String) {
                if (Get() <= 0) Set(selections.Length - 1);
                else Set(Get() - 1);
            }
            else if (valueType == ValueType.Number) {
                float increment = Increment > 1f && Input.GetKeyInt(KeyCode.LeftShift) ? Increment / 2 : Increment;
                if (GetFloat() - increment < Min - 0.001f) Set(Max);
                else Set(GetFloat() - increment);
            }
        }
    }
}