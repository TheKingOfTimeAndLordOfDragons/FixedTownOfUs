using System.Collections.Generic;
using System.Linq;
using System.Text;
using HarmonyLib;
using TownOfUs.Extensions;
using UnityEngine;

namespace TownOfUs.CustomOption
{
    [HarmonyPatch(typeof(GameOptionsMenu), nameof(GameOptionsMenu.Start))]
    public class GameOptionsMenuStartPatch {
        public static void Postfix(GameOptionsMenu __instance) {
            createClassicTabs(__instance);
        }

        private static void createClassicTabs(GameOptionsMenu __instance) {
            bool isReturn = setNames(
                new Dictionary<string, string>() {
                    ["TOUSettings"] = Language.GetString("option.tab.general"),
                    ["CrewmateSettings"] = Language.GetString("option.tab.crewmate"),
                    ["NeutralSettings"] = Language.GetString("option.tab.neutral"),
                    ["ImpostorSettings"] = Language.GetString("option.tab.impostor"),
                    ["ModifierSettings"] = Language.GetString("option.tab.modifier")
                }
            );
            if (isReturn) return;

            // Setup TOU tab
            StringOption stringTemplate = UnityEngine.Object.FindObjectsOfType<StringOption>().FirstOrDefault();
            ToggleOption toggleTemplate = UnityEngine.Object.FindObjectsOfType<ToggleOption>().FirstOrDefault();
            NumberOption numberTemplate = UnityEngine.Object.FindObjectsOfType<NumberOption>().FirstOrDefault();
            if (stringTemplate == null || toggleTemplate == null || numberTemplate == null) return;

            var gameSettings = GameObject.Find("Game Settings");
            var gameSettingMenu = UnityEngine.Object.FindObjectsOfType<GameSettingMenu>().FirstOrDefault();
            gameSettings.transform.FindChild("GameGroup").GetComponent<Scroller>().ScrollWheelSpeed = 1f;

            var touSettings = UnityEngine.Object.Instantiate(gameSettings, gameSettings.transform.parent);
            var touMenu = getMenu(touSettings, "TOUSettings");
            touSettings.transform.FindChild("GameGroup").GetComponent<Scroller>().ScrollWheelSpeed = 1f;

            var crewmateSettings = UnityEngine.Object.Instantiate(gameSettings, gameSettings.transform.parent);
            var crewmateMenu = getMenu(crewmateSettings, "CrewmateSettings");
            crewmateSettings.transform.FindChild("GameGroup").GetComponent<Scroller>().ScrollWheelSpeed = 1f;
            
            var neutralSettings = UnityEngine.Object.Instantiate(gameSettings, gameSettings.transform.parent);
            var neutralMenu = getMenu(neutralSettings, "NeutralSettings");
            neutralSettings.transform.FindChild("GameGroup").GetComponent<Scroller>().ScrollWheelSpeed = 1f;
            
            var impostorSettings = UnityEngine.Object.Instantiate(gameSettings, gameSettings.transform.parent);
            var impostorMenu = getMenu(impostorSettings, "ImpostorSettings");
            impostorSettings.transform.FindChild("GameGroup").GetComponent<Scroller>().ScrollWheelSpeed = 1f;
            
            var modifierSettings = UnityEngine.Object.Instantiate(gameSettings, gameSettings.transform.parent);
            var modifierMenu = getMenu(modifierSettings, "ModifierSettings");
            modifierSettings.transform.FindChild("GameGroup").GetComponent<Scroller>().ScrollWheelSpeed = 1f;

            var roleTab = GameObject.Find("RoleTab");
            var gameTab = GameObject.Find("GameTab");

            var touTab = UnityEngine.Object.Instantiate(roleTab, gameTab.transform.parent);
            var touTabHighlight = getTabHighlight(touTab, "TownOfUsTab", "TownOfUs.Resources.SettingsButton.png");

            var crewmateTab = UnityEngine.Object.Instantiate(roleTab, touTab.transform);
            var crewmateTabHighlight = getTabHighlight(crewmateTab, "CrewmateTab", "TownOfUs.Resources.Crewmate.png");

            var neutralTab = UnityEngine.Object.Instantiate(roleTab, crewmateTab.transform);
            var neutralTabHighlight = getTabHighlight(neutralTab, "NeutralTab", "TownOfUs.Resources.Neutral.png");

            var impostorTab = UnityEngine.Object.Instantiate(roleTab, neutralTab.transform);
            var impostorTabHighlight = getTabHighlight(impostorTab, "ImpostorTab", "TownOfUs.Resources.Impostor.png");

            var modifierTab = UnityEngine.Object.Instantiate(roleTab, impostorTab.transform);
            var modifierTabHighlight = getTabHighlight(modifierTab, "ModifierTab", "TownOfUs.Resources.Modifiers.png");

            // Position of Tab Icons
            gameTab.transform.position += Vector3.left * 3f;
            roleTab.transform.position += Vector3.left * 3f;
            touTab.transform.position += Vector3.left * 2f;
            crewmateTab.transform.localPosition = Vector3.right * 1f;
            neutralTab.transform.localPosition = Vector3.right * 1f;
            impostorTab.transform.localPosition = Vector3.right * 1f;
            modifierTab.transform.localPosition = Vector3.right * 1f;

            var tabs = new GameObject[] { gameTab, roleTab, touTab, crewmateTab, neutralTab, impostorTab, modifierTab };
            var settingsHighlightMap = new Dictionary<GameObject, SpriteRenderer> {
                [gameSettingMenu.RegularGameSettings] = gameSettingMenu.GameSettingsHightlight,
                [gameSettingMenu.RolesSettings.gameObject] = gameSettingMenu.RolesSettingsHightlight,
                [touSettings.gameObject] = touTabHighlight,
                [crewmateSettings.gameObject] = crewmateTabHighlight,
                [neutralSettings.gameObject] = neutralTabHighlight,
                [impostorSettings.gameObject] = impostorTabHighlight,
                [modifierSettings.gameObject] = modifierTabHighlight
            };
            
            for (int i = 0; i < tabs.Length; i++) {
                var button = tabs[i].GetComponentInChildren<PassiveButton>();
                if (button == null) continue;
                int copiedIndex = i;
                button.OnClick = new UnityEngine.UI.Button.ButtonClickedEvent();
                button.OnClick.AddListener((System.Action)(() => {
                    setListener(settingsHighlightMap, copiedIndex);
                }));
            }

            destroyOptions(new List<List<OptionBehaviour>>{
                touMenu.GetComponentsInChildren<OptionBehaviour>().ToList(),
                crewmateMenu.GetComponentsInChildren<OptionBehaviour>().ToList(),
                neutralMenu.GetComponentsInChildren<OptionBehaviour>().ToList(),
                impostorMenu.GetComponentsInChildren<OptionBehaviour>().ToList(),
                modifierMenu.GetComponentsInChildren<OptionBehaviour>().ToList()
            });

            List<OptionBehaviour> touOptions = new List<OptionBehaviour>();
            List<OptionBehaviour> crewmateOptions = new List<OptionBehaviour>();
            List<OptionBehaviour> neutralOptions = new List<OptionBehaviour>();
            List<OptionBehaviour> impostorOptions = new List<OptionBehaviour>();
            List<OptionBehaviour> modifierOptions = new List<OptionBehaviour>();

            List<Transform> menus = new List<Transform>() { touMenu.transform, crewmateMenu.transform, neutralMenu.transform, impostorMenu.transform, modifierMenu.transform };
            List<List<OptionBehaviour>> optionBehaviours = new List<List<OptionBehaviour>>() { touOptions, crewmateOptions, neutralOptions, impostorOptions, modifierOptions };
            for (int i = 0; i < CustomOption.options.Count; i++) {
                CustomOption option = CustomOption.options[i];
                if (option.optionBehaviour == null) {
                    if (option.valueType == CustomOption.ValueType.Header) {
                        ToggleOption toggleOption2 = Object.Instantiate(toggleTemplate, menus[(int)option.type]);
                        toggleOption2.transform.GetChild(1).gameObject.SetActive(false);
                        toggleOption2.transform.GetChild(2).gameObject.SetActive(false);
                        optionBehaviours[(int)option.type].Add(toggleOption2);
                        toggleOption2.TitleText.text = option.name;
                        option.optionBehaviour = toggleOption2;
                    } else if (option.valueType == CustomOption.ValueType.String) {
                        StringOption stringOption = Object.Instantiate(stringTemplate, menus[(int)option.type]);
                        optionBehaviours[(int)option.type].Add(stringOption);
                        stringOption.OnValueChanged = ((System.Action<OptionBehaviour>)delegate
                        {
                        });
                        stringOption.TitleText.text = option.name;
                        int value = (stringOption.oldValue = option);
                        stringOption.Value = value;
                        stringOption.ValueText.text = option;
                        option.optionBehaviour = stringOption;
                    } else if (option.valueType == CustomOption.ValueType.Toggle) {
                        ToggleOption toggleOption = Object.Instantiate(toggleTemplate, menus[(int)option.type]);
                        optionBehaviours[(int)option.type].Add(toggleOption);
                        toggleOption.OnValueChanged = ((System.Action<OptionBehaviour>)delegate
                        {
                        });
                        toggleOption.TitleText.text = option.name;
                        toggleOption.CheckMark.enabled = option;
                        option.optionBehaviour = toggleOption;
                    } else if (option.valueType == CustomOption.ValueType.Number) {
                        NumberOption numberOption = Object.Instantiate(numberTemplate, menus[(int)option.type]);
                        optionBehaviours[(int)option.type].Add(numberOption);
                        numberOption.OnValueChanged = ((System.Action<OptionBehaviour>)delegate
                        {
                        });
                        numberOption.TitleText.text = option.name;
                        float value = (numberOption.oldValue = option);
                        numberOption.Value = value;
                        numberOption.ValueText.text = option.ToString();
                        option.optionBehaviour = numberOption;
                    }
                }
                option.optionBehaviour.gameObject.SetActive(true);
            }

            setOptions(
                new List<GameOptionsMenu> { touMenu, crewmateMenu, neutralMenu, impostorMenu, modifierMenu },
                new List<List<OptionBehaviour>> { touOptions, crewmateOptions, neutralOptions, impostorOptions, modifierOptions },
                new List<GameObject> { touSettings, crewmateSettings, neutralSettings, impostorSettings, modifierSettings }
            );

            adaptTaskCount(__instance);
        }

        private static void setListener(Dictionary<GameObject, SpriteRenderer> settingsHighlightMap, int index) {
            foreach (KeyValuePair<GameObject, SpriteRenderer> entry in settingsHighlightMap) {
                entry.Key.SetActive(false);
                entry.Value.enabled = false;
            }
            settingsHighlightMap.ElementAt(index).Key.SetActive(true);
            settingsHighlightMap.ElementAt(index).Value.enabled = true;
        }

        private static void destroyOptions (List<List<OptionBehaviour>> optionBehavioursList) {
           foreach (List<OptionBehaviour> optionBehaviours in optionBehavioursList) {
                foreach (OptionBehaviour option in optionBehaviours)
                    UnityEngine.Object.Destroy(option.gameObject);
            }
        }

        private static bool setNames (Dictionary<string, string> gameObjectNameDisplayNameMap) {
            foreach (KeyValuePair <string, string> entry in gameObjectNameDisplayNameMap) {
                if (GameObject.Find(entry.Key) != null) { // Settings setup has already been performed, fixing the title of the tab and returning
                    GameObject.Find(entry.Key).transform.FindChild("GameGroup").FindChild("Text").GetComponent<TMPro.TextMeshPro>().SetText(entry.Value);
                    return true;
                }
            }
            return false;
        }

        private static GameOptionsMenu getMenu(GameObject setting, string settingName) {
            var menu = setting.transform.FindChild("GameGroup").FindChild("SliderInner").GetComponent<GameOptionsMenu>();
            setting.name = settingName;
            return menu;
        }

        private static SpriteRenderer getTabHighlight (GameObject tab, string tabName, string tabSpritePath) {
            var tabHighlight = tab.transform.FindChild("Hat Button").FindChild("Tab Background").GetComponent<SpriteRenderer>();
            tab.transform.FindChild("Hat Button").FindChild("Icon").GetComponent<SpriteRenderer>().sprite = Utils.loadSpriteFromResources(tabSpritePath, 100f);
            tab.name = "tabName";
            return tabHighlight;
        }

        private static void setOptions (List<GameOptionsMenu> menus, List<List<OptionBehaviour>> options, List<GameObject> settings) {
            if (!(menus.Count == options.Count && options.Count == settings.Count)) {
                TownOfUs.Logger.LogError("List counts are not equal");
                return;
            }
            for (int i = 0; i < menus.Count; i++) {
                menus[i].Children = options[i].ToArray();
                settings[i].gameObject.SetActive(false);
            }
        }

        private static void adaptTaskCount(GameOptionsMenu __instance) {
            // Adapt task count for main options
            var commonTasksOption = __instance.Children.FirstOrDefault(x => x.name == "NumCommonTasks").TryCast<NumberOption>();
            if (commonTasksOption != null) commonTasksOption.ValidRange = new FloatRange(0f, 4f);

            var shortTasksOption = __instance.Children.FirstOrDefault(x => x.name == "NumShortTasks").TryCast<NumberOption>();
            if (shortTasksOption != null) shortTasksOption.ValidRange = new FloatRange(0f, 23f);

            var longTasksOption = __instance.Children.FirstOrDefault(x => x.name == "NumLongTasks").TryCast<NumberOption>();
            if (longTasksOption != null) longTasksOption.ValidRange = new FloatRange(0f, 15f);
        }
    }

    [HarmonyPatch(typeof(GameOptionsMenu), nameof(GameOptionsMenu.Update))]
    public class GameOptionsMenuUpdatePatch {
        private static float timer = 1f;

        public static void Postfix(GameOptionsMenu __instance) {
            // Return Menu Update if in normal among us settings 
            var gameSettingMenu = UnityEngine.Object.FindObjectsOfType<GameSettingMenu>().FirstOrDefault();
            if (gameSettingMenu.RegularGameSettings.active || gameSettingMenu.RolesSettings.gameObject.active) return;

            timer += Time.deltaTime;
            if (timer < 0.1f) return;
            timer = 0f;

            float numItems = __instance.Children.Length;
            var offset = 2.7f;

            foreach (CustomOption option in CustomOption.options) {
                if (GameObject.Find("TOUSettings") && option.type != CustomOption.CustomOptionType.General)
                    continue;
                if (GameObject.Find("CrewmateSettings") && option.type != CustomOption.CustomOptionType.Crewmate)
                    continue;
                if (GameObject.Find("NeutralSettings") && option.type != CustomOption.CustomOptionType.Neutral)
                    continue;
                if (GameObject.Find("ImpostorSettings") && option.type != CustomOption.CustomOptionType.Impostor)
                    continue;
                if (GameObject.Find("ModifierSettings") && option.type != CustomOption.CustomOptionType.Modifier)
                    continue;
                
                if (option?.optionBehaviour != null && option.optionBehaviour.gameObject != null) {
                    var enabled = true;
                    var parent = option.parent;
                    enabled = !option.IsHiddenOn(Generate.CurrentGameMode);

                    while (parent != null && enabled) {
                        enabled = parent.GetBool();
                        parent = parent.parent;
                    }
                    option.optionBehaviour.gameObject.SetActive(enabled);
                    if (enabled) {
                        offset -= option.isHeader ? 0.7f : 0.5f;
                        option.optionBehaviour.transform.localPosition = new Vector3(option.optionBehaviour.transform.localPosition.x, offset, option.optionBehaviour.transform.localPosition.z);

                        if (option.isHeader) numItems += 0.5f;
                    } 
                    else {
                        numItems--;
                    }
                }
                __instance.GetComponentInParent<Scroller>().ContentYBounds.max = (-offset) - 1.5f;
            }
        }
    }

    [HarmonyPatch]
    public class GameOptionsDataPatch {
        private static string buildOptionsOfType(CustomOption.CustomOptionType type, bool headerOnly) {
            StringBuilder sb = new StringBuilder("\n");
            var options = CustomOption.options.Where(o => o.type == type);

            foreach (var option in options) {
                if (option.parent == null && option.valueType != CustomOption.ValueType.Header) {
                    string line = "";
                    if (Generate.CurrentGameMode == GameMode.Classic) {
                        if (option.GameMode == GameMode.Classic || option.GameMode == GameMode.All)
                            line = $"{option.name}: {option.ToString()}";
                    } else if (Generate.CurrentGameMode == GameMode.AllAny) {
                        if (option.GameMode == GameMode.AllAny || option.GameMode == GameMode.All)
                            line = $"{option.name}: {option.ToString()}";
                    } else if (Generate.CurrentGameMode == GameMode.KillingOnly) {
                        if (option.GameMode == GameMode.KillingOnly || option.GameMode == GameMode.All)
                            line = $"{option.name}: {option.ToString()}";
                    } else if (Generate.CurrentGameMode == GameMode.Cultist) {
                        if (option.GameMode == GameMode.Cultist || option.GameMode == GameMode.All)
                            line = $"{option.name}: {option.ToString()}";
                    }
                    sb.AppendLine(line);
                }
            }
            if (headerOnly) return sb.ToString();
            else sb = new StringBuilder();

            foreach (CustomOption option in options) {
                if (option.parent != null) {
                    bool isIrrelevant = option.parent.Get() == 0 || (option.parent.parent != null && option.parent.parent.Get() == 0);
                    Color c = isIrrelevant ? Color.grey : Color.white;  // No use for now
                    if (isIrrelevant) continue;
                    if (option.parent.parent != null) {
                        if (Generate.CurrentGameMode == GameMode.Classic) {
                            if (option.GameMode == GameMode.Classic || option.GameMode == GameMode.All)
                                sb.AppendLine(CustomOption.cs(c, $"    {option.name}: {option.ToString()}"));
                        } else if (Generate.CurrentGameMode == GameMode.AllAny) {
                            if (option.GameMode == GameMode.AllAny || option.GameMode == GameMode.All)
                                sb.AppendLine(CustomOption.cs(c, $"    {option.name}: {option.ToString()}"));
                        } else if (Generate.CurrentGameMode == GameMode.KillingOnly) {
                            if (option.GameMode == GameMode.KillingOnly || option.GameMode == GameMode.All)
                                sb.AppendLine(CustomOption.cs(c, $"    {option.name}: {option.ToString()}"));
                        } else if (Generate.CurrentGameMode == GameMode.Cultist) {
                            if (option.GameMode == GameMode.Cultist || option.GameMode == GameMode.All)
                                sb.AppendLine(CustomOption.cs(c, $"    {option.name}: {option.ToString()}"));
                        }
                    } else {
                        if (Generate.CurrentGameMode == GameMode.Classic) {
                            if (option.GameMode == GameMode.Classic || option.GameMode == GameMode.All)
                                sb.AppendLine(CustomOption.cs(c, $"  {option.name}: {option.ToString()}"));
                        } else if (Generate.CurrentGameMode == GameMode.AllAny) {
                            if (option.GameMode == GameMode.AllAny || option.GameMode == GameMode.All)
                                sb.AppendLine(CustomOption.cs(c, $"  {option.name}: {option.ToString()}"));
                        } else if (Generate.CurrentGameMode == GameMode.KillingOnly) {
                            if (option.GameMode == GameMode.KillingOnly || option.GameMode == GameMode.All)
                                sb.AppendLine(CustomOption.cs(c, $"  {option.name}: {option.ToString()}"));
                        } else if (Generate.CurrentGameMode == GameMode.Cultist) {
                            if (option.GameMode == GameMode.Cultist || option.GameMode == GameMode.All)
                                sb.AppendLine(CustomOption.cs(c, $"  {option.name}: {option.ToString()}"));
                        }
                    }
                } else {
                    if (option.valueType == CustomOption.ValueType.Header) {
                        if (Generate.CurrentGameMode == GameMode.Classic) {
                            if (option.GameMode == GameMode.Classic || option.GameMode == GameMode.All)
                                sb.AppendLine($"\n{option.name}");
                        } else if (Generate.CurrentGameMode == GameMode.AllAny) {
                            if (option.GameMode == GameMode.AllAny || option.GameMode == GameMode.All)
                                sb.AppendLine($"\n{option.name}");
                        } else if (Generate.CurrentGameMode == GameMode.KillingOnly) {
                            if (option.GameMode == GameMode.KillingOnly || option.GameMode == GameMode.All)
                                sb.AppendLine($"\n{option.name}");
                        } else if (Generate.CurrentGameMode == GameMode.Cultist) {
                            if (option.GameMode == GameMode.Cultist || option.GameMode == GameMode.All)
                                sb.AppendLine($"\n{option.name}");
                        }
                    } else {
                        if (Generate.CurrentGameMode == GameMode.Classic) {
                            if (option.GameMode == GameMode.Classic || option.GameMode == GameMode.All)
                                sb.AppendLine($"{option.name}: {option.ToString()}");
                        } else if (Generate.CurrentGameMode == GameMode.AllAny) {
                            if (option.GameMode == GameMode.AllAny || option.GameMode == GameMode.All)
                                sb.AppendLine($"{option.name}: {option.ToString()}");
                        } else if (Generate.CurrentGameMode == GameMode.KillingOnly) {
                            if (option.GameMode == GameMode.KillingOnly || option.GameMode == GameMode.All)
                                sb.AppendLine($"{option.name}: {option.ToString()}");
                        } else if (Generate.CurrentGameMode == GameMode.Cultist) {
                            if (option.GameMode == GameMode.Cultist || option.GameMode == GameMode.All)
                                sb.AppendLine($"{option.name}: {option.ToString()}");
                        }
                    }
                }
            }
            return sb.ToString();
        }

        public static string buildAllOptions(string vanillaSettings = "", bool hideExtras = false) {
            if (vanillaSettings == "")
                vanillaSettings = GameOptionsManager.Instance.CurrentGameOptions.ToHudString(PlayerControl.AllPlayerControls.Count);
            int counter = TownOfUs.optionsPage;
            int maxPage = 6;
            string hudString = counter != 0 && !hideExtras ? CustomOption.cs(System.DateTime.Now.Second % 2 == 0 ? Color.white : Color.red, "(" + Language.GetString("option.page.scroll") + ")\n\n") : "";

            switch (counter) {
                case 0:
                    hudString += Language.GetString("option.page.one") + " \n" + vanillaSettings;
                    break;
                case 1:
                    hudString += Language.GetString("option.page.two") + " \n" + buildOptionsOfType(CustomOption.CustomOptionType.General, false);
                    break;
                case 2:
                    hudString += Language.GetString("option.page.three") + " \n" + buildOptionsOfType(CustomOption.CustomOptionType.Crewmate, false);
                    break;
                case 3:
                    hudString += Language.GetString("option.page.four") + " \n" + buildOptionsOfType(CustomOption.CustomOptionType.Neutral, false);
                    break;
                case 4:
                    hudString += Language.GetString("option.page.five") + " \n" + buildOptionsOfType(CustomOption.CustomOptionType.Impostor, false);
                    break;
                case 5:
                    hudString += Language.GetString("option.page.six") + " \n" + buildOptionsOfType(CustomOption.CustomOptionType.Modifier, false);
                    break;
            }

            hudString += $"\n " + Language.GetString("option.page.toggle").Replace("%PAGE%", (counter + 1).ToString()).Replace("%MAX%", maxPage.ToString());
            return hudString;
        }

        [HarmonyPatch(typeof(IGameOptionsExtensions), nameof(IGameOptionsExtensions.ToHudString))]
        private static void Postfix(ref string __result)
        {
            if (GameOptionsManager.Instance.currentGameOptions.GameMode == AmongUs.GameOptions.GameModes.HideNSeek) return; // Allow Vanilla Hide N Seek
            __result = buildAllOptions(vanillaSettings:__result);
        }
    }

    [HarmonyPatch(typeof(KeyboardJoystick), nameof(KeyboardJoystick.Update))]
    public static class GameOptionsNextPagePatch {
        public static void Postfix(KeyboardJoystick __instance) {
            int page = TownOfUs.optionsPage;
            if (Input.GetKeyDown(KeyCode.Tab)) {
                TownOfUs.optionsPage++;
                if (TownOfUs.optionsPage == 6) TownOfUs.optionsPage = 0;
            }
            if (Input.GetKeyDown(KeyCode.LeftShift)) {
                TownOfUs.optionsPage--;
                if (TownOfUs.optionsPage == -1) TownOfUs.optionsPage = 5;
            }
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) {
                TownOfUs.optionsPage = 0;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) {
                TownOfUs.optionsPage = 1;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)) {
                TownOfUs.optionsPage = 2;
            }
            if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4)) {
                TownOfUs.optionsPage = 3;
            }
            if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5)) {
                TownOfUs.optionsPage = 4;
            }
            if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6)) {
                TownOfUs.optionsPage = 5;
            }

            if (page != TownOfUs.optionsPage) {
                Vector3 position = (Vector3)DestroyableSingleton<HudManager>.Instance?.GameSettings?.transform.localPosition;
                DestroyableSingleton<HudManager>.Instance.GameSettings.transform.localPosition = new Vector3(position.x, 2.9f, position.z);
            }
        }
    }

    [HarmonyPatch(typeof(StringOption), nameof(StringOption.OnEnable))]
    public class StringOptionEnablePatch {
        public static bool Prefix(StringOption __instance) {
            CustomOption option = CustomOption.options.FirstOrDefault(option => option.optionBehaviour == __instance);
            if (option == null) return true;

            __instance.OnValueChanged = ((System.Action<OptionBehaviour>)delegate
            {
            });
            __instance.TitleText.text = option.name;
            int value = (__instance.oldValue = option);
            __instance.Value = value;
            __instance.ValueText.text = option;
            
            return false;
        }
    }
    
    [HarmonyPatch(typeof(StringOption), nameof(StringOption.Increase))]
    public class StringOptionIncreasePatch
    {
        public static bool Prefix(StringOption __instance)
        {
            CustomOption option = CustomOption.options.FirstOrDefault(option => option.optionBehaviour == __instance);
            if (option == null) return true;
            option.Increase();
            return false;
        }
    }

    [HarmonyPatch(typeof(StringOption), nameof(StringOption.Decrease))]
    public class StringOptionDecreasePatch
    {
        public static bool Prefix(StringOption __instance)
        {
            CustomOption option = CustomOption.options.FirstOrDefault(option => option.optionBehaviour == __instance);
            if (option == null) return true;
            option.Decrease();
            return false;
        }
    }

    [HarmonyPatch(typeof(NumberOption), nameof(NumberOption.OnEnable))]
    public class NumberOptionEnablePatch {
        public static bool Prefix(NumberOption __instance) {
            CustomOption option = CustomOption.options.FirstOrDefault(option => option.optionBehaviour == __instance);
            if (option == null) return true;

            __instance.OnValueChanged = ((System.Action<OptionBehaviour>)delegate
            {
            });
            __instance.TitleText.text = option.name;
            __instance.ValidRange = new FloatRange(option.Min, option.Max);
            __instance.Increment = option.Increment;
            float value = (__instance.oldValue = option);
            __instance.Value = value;
            __instance.ValueText.text = option.ToString();
            
            return false;
        }
    }
    
    [HarmonyPatch(typeof(NumberOption), nameof(NumberOption.Increase))]
    public class NumberOptionIncreasePatch
    {
        public static bool Prefix(NumberOption __instance)
        {
            CustomOption option = CustomOption.options.FirstOrDefault(option => option.optionBehaviour == __instance);
            if (option == null) return true;
            option.Increase();
            return false;
        }
    }

    [HarmonyPatch(typeof(NumberOption), nameof(NumberOption.Decrease))]
    public class NumberOptionDecreasePatch
    {
        public static bool Prefix(NumberOption __instance)
        {
            CustomOption option = CustomOption.options.FirstOrDefault(option => option.optionBehaviour == __instance);
            if (option == null) return true;
            option.Decrease();
            return false;
        }
    }

    [HarmonyPatch(typeof(ToggleOption), nameof(ToggleOption.OnEnable))]
    public class ToggleOptionEnablePatch {
        public static bool Prefix(ToggleOption __instance) {
            CustomOption option = CustomOption.options.FirstOrDefault(option => option.optionBehaviour == __instance);
            if (option == null) return true;

            __instance.TitleText.text = option.name;
            if (option.valueType == CustomOption.ValueType.Header) return false;
            __instance.OnValueChanged = ((System.Action<OptionBehaviour>)delegate
            {
            });
            __instance.CheckMark.enabled = option;

            return false;
        }
    }

    [HarmonyPatch(typeof(ToggleOption), nameof(ToggleOption.Toggle))]
    public class ToggleOptionDecreasePatch
    {
        public static bool Prefix(ToggleOption __instance)
        {
            CustomOption option = CustomOption.options.FirstOrDefault(option => option.optionBehaviour == __instance);
            if (option == null) return true;
            if (option.valueType == CustomOption.ValueType.Header) return false;
            option.Toggle();
            return false;
        }
    }

    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.RpcSyncSettings))]
    public class RpcSyncSettingsPatch
    {
        public static void Postfix()
        {
            CustomOption.SendRpc();
            CustomOption.SaveBaseOptions();
        }
    }

    [HarmonyPatch(typeof(PlayerPhysics), nameof(PlayerPhysics.CoSpawnPlayer))]
    public class AmongUsClientOnPlayerJoinedPatch {
        public static void Postfix() {
            if (PlayerControl.AllPlayerControls.Count >= 2 && AmongUsClient.Instance && PlayerControl.LocalPlayer && AmongUsClient.Instance.AmHost) {
                CustomOption.SendRpc();
            }
        }
    }

    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public class GameSettingsScalePatch {
        public static void Prefix(HudManager __instance) {
            if (__instance.GameSettings != null) __instance.GameSettings.fontSize = 1.2f; 
        }
    }

    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public class HudManagerUpdate {
        public static float
            MinX,/*-5.3F*/
            OriginalY = 2.9F,
            MinY = 2.9F;
        
        public static Scroller Scroller;
        private static Vector3 LastPosition;
        private static float lastAspect;
        private static bool setLastPosition = false;

        public static void Prefix(HudManager __instance) {
            if (__instance.GameSettings?.transform == null) return;

            // Sets the MinX position to the left edge of the screen + 0.1 units
            Rect safeArea = Screen.safeArea;
            float aspect = Mathf.Min((Camera.main).aspect, safeArea.width / safeArea.height);
            float safeOrthographicSize = CameraSafeArea.GetSafeOrthographicSize(Camera.main);
            MinX = 0.1f - safeOrthographicSize * aspect;

            if (!setLastPosition || aspect != lastAspect) {
                LastPosition = new Vector3(MinX, MinY);
                lastAspect = aspect;
                setLastPosition = true;
                if (Scroller != null) Scroller.ContentXBounds = new FloatRange(MinX, MinX);                
            }

            CreateScroller(__instance);

            Scroller.gameObject.SetActive(__instance.GameSettings.gameObject.activeSelf);

            if (!Scroller.gameObject.active) return;

            var rows = __instance.GameSettings.text.Count(c => c == '\n');
            float LobbyTextRowHeight = 0.06F;
            var maxY = Mathf.Max(MinY, rows * LobbyTextRowHeight + (rows - 1) * LobbyTextRowHeight);

            Scroller.ContentYBounds = new FloatRange(MinY, maxY);

            // Prevent scrolling when the player is interacting with a menu
            if (PlayerControl.LocalPlayer?.CanMove != true) {
                __instance.GameSettings.transform.localPosition = LastPosition;
                return;
            }

            if (__instance.GameSettings.transform.localPosition.x != MinX ||
                __instance.GameSettings.transform.localPosition.y < MinY) return;
            
            LastPosition = __instance.GameSettings.transform.localPosition;
        }

        private static void CreateScroller(HudManager __instance) {
            if (Scroller != null) return;

            Transform target = __instance.GameSettings.transform;

            Scroller = new GameObject("SettingsScroller").AddComponent<Scroller>();
            Scroller.transform.SetParent(__instance.GameSettings.transform.parent);
            Scroller.gameObject.layer = 5;

            Scroller.transform.localScale = Vector3.one;
            Scroller.allowX = false;
            Scroller.allowY = true;
            Scroller.active = true;
            Scroller.velocity = new Vector2(0, 0);
            Scroller.ScrollbarYBounds = new FloatRange(0, 0);
            Scroller.ContentXBounds = new FloatRange(MinX, MinX);
            Scroller.enabled = true;

            Scroller.Inner = target;
            target.SetParent(Scroller.transform);
        }
    }
}