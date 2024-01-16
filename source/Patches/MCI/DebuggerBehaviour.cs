using System;
using AmongUs.Data;
using Reactor.Utilities.ImGui;
using UnityEngine;
using Il2CppInterop.Runtime.Attributes;
using Random = UnityEngine.Random;
using Reactor.Utilities.Extensions;
using TownOfUs.Roles;

namespace TownOfUs.MCI
{
    //Based off of Reactor.Debugger but merged with MCI and added some functions and changes of my own for testing
    public class DebuggerBehaviour : MonoBehaviour
    {
        [HideFromIl2Cpp]
        public DragWindow TestWindow { get; }

        [HideFromIl2Cpp]
        public DragWindow CooldownsWindow { get; }

        public byte ControllingFigure;

        public static DebuggerBehaviour Instance { get; private set; }

        public DebuggerBehaviour(IntPtr ptr) : base(ptr)
        {
            if (Instance)
                this.Destroy();

            Instance = this;

            TestWindow = new(new(20, 20, 0, 0), "Town Of Us Debugger", () =>
            {
                GUILayout.Label("Name: " + DataManager.Player.Customization.Name);

                if (GUILayout.Button("Close Testing Menu"))
                    TestWindow.Enabled = false;

                if (PlayerControl.LocalPlayer && !ConstantVariables.NoLobby && !PlayerControl.LocalPlayer.Data.IsDead && !ConstantVariables.IsEnded && !ConstantVariables.GameHasEnded)
                    PlayerControl.LocalPlayer.Collider.enabled = GUILayout.Toggle(PlayerControl.LocalPlayer.Collider.enabled, "Enable Player Collider");

                if (ConstantVariables.IsLobby)
                {
                    TownOfUs.LobbyCapped = GUILayout.Toggle(TownOfUs.LobbyCapped, "Toggle Lobby Cap");
                    TownOfUs.Persistence = GUILayout.Toggle(TownOfUs.Persistence, "Toggle Bot Persistence");

                    if (GUILayout.Button("Spawn Bot"))
                    {
                        if ((PlayerControl.AllPlayerControls.Count < GameOptionsManager.Instance.currentNormalGameOptions.MaxPlayers && TownOfUs.LobbyCapped) || !TownOfUs.LobbyCapped)
                        {
                            MCIUtils.CleanUpLoad();
                            MCIUtils.CreatePlayerInstance();
                            TownOfUs.MCIActive = true;
                        }
                    }

                    if (GUILayout.Button("Remove Last Bot"))
                    {
                        MCIUtils.RemovePlayer((byte)MCIUtils.Clients.Count);
                        ControllingFigure = 0;

                        if (MCIUtils.Clients.Count == 0)
                            TownOfUs.MCIActive = false;
                    }

                    if (GUILayout.Button("Remove All Bots"))
                    {
                        MCIUtils.RemoveAllPlayers();
                        ControllingFigure = 0;
                        TownOfUs.MCIActive = false;
                    }
                }
                else if (TownOfUs.MCIActive)
                {
                    if (GUILayout.Button("Next Player"))
                    {
                        ControllingFigure = Utils.CycleByte(PlayerControl.AllPlayerControls.Count - 1, 0, ControllingFigure, true);
                        MCIUtils.SwitchTo(ControllingFigure);
                    }
                    else if (GUILayout.Button("Previous Player"))
                    {
                        ControllingFigure = Utils.CycleByte(PlayerControl.AllPlayerControls.Count - 1, 0, ControllingFigure, false);
                        MCIUtils.SwitchTo(ControllingFigure);
                    }

                    if (GUILayout.Button("End Game"))
                    {
                        Role.NobodyWins = true;
                        Utils.EndGame();
                    }

                    if (GUILayout.Button("Fix All Sabotages"))
                    {
                        ShipStatus.Instance.RpcRepairSystem(SystemTypes.Doors, 79);
                        ShipStatus.Instance.RpcRepairSystem(SystemTypes.Doors, 80);
                        ShipStatus.Instance.RpcRepairSystem(SystemTypes.Doors, 81);
                        ShipStatus.Instance.RpcRepairSystem(SystemTypes.Doors, 82);
                        ShipStatus.Instance.RpcRepairSystem(SystemTypes.LifeSupp, 16);
                        ShipStatus.Instance.RpcRepairSystem(SystemTypes.Reactor, 16);
                        ShipStatus.Instance.RpcRepairSystem(SystemTypes.Laboratory, 16);
                        ShipStatus.Instance.RpcRepairSystem(SystemTypes.Reactor, 16 | 0);
                        ShipStatus.Instance.RpcRepairSystem(SystemTypes.Reactor, 16 | 1);
                        ShipStatus.Instance.RpcRepairSystem(SystemTypes.Comms, 16 | 0);
                        ShipStatus.Instance.RpcRepairSystem(SystemTypes.Comms, 16 | 1);
                        ShipStatus.Instance.RpcRepairSystem(SystemTypes.Comms, 0);
                        Utils.UnCamouflage();
                    }

                    if (GUILayout.Button("Complete Tasks"))
                    {
                        foreach (var task in PlayerControl.LocalPlayer.myTasks)
                            PlayerControl.LocalPlayer.RpcCompleteTask(task.Id);
                    }

                    if (GUILayout.Button("Complete Everyone's Tasks"))
                    {
                        foreach (PlayerControl player in PlayerControl.AllPlayerControls)
                            foreach (var task in PlayerControl.LocalPlayer.myTasks)
                                PlayerControl.LocalPlayer.RpcCompleteTask(task.Id);
                    }

                    if (GUILayout.Button("Redo Intro Sequence"))
                    {
                        HudManager.Instance.StartCoroutine(HudManager.Instance.CoFadeFullScreen(Color.clear, Color.black));
                        HudManager.Instance.StartCoroutine(HudManager.Instance.CoShowIntro());
                    }

                    if (GUILayout.Button("Start Meeting") && !MeetingHud.Instance)
                    {
                        PlayerControl.LocalPlayer.RemainingEmergencies++;
                        PlayerControl.LocalPlayer.CmdReportDeadBody(null);
                    }

                    if (GUILayout.Button("End Meeting") && MeetingHud.Instance)
                        MeetingHud.Instance.RpcClose();

                    if (GUILayout.Button("Kill Self"))
                        Utils.RpcMurderPlayer(PlayerControl.LocalPlayer, PlayerControl.LocalPlayer);

                    if (GUILayout.Button("Kill All"))
                    {
                        foreach (var player in PlayerControl.AllPlayerControls)
                            Utils.RpcMurderPlayer(player, player);
                    }

                    if (GUILayout.Button("Open Cooldowns Menu"))
                        CooldownsWindow.Enabled = true;
                }

                if (PlayerControl.LocalPlayer)
                {
                    var position = PlayerControl.LocalPlayer.transform.position;
                    GUILayout.Label($"Player Position\nx: {position.x:00.00} y: {position.y:00.00} z: {position.z:00.00}");

                    var mouse = Input.mousePosition;
                    GUILayout.Label($"Mouse Position\nx: {mouse.x:00.00} y: {mouse.y:00.00} z: {mouse.z:00.00}");
                }
            })
            {
                Enabled = false
            };

            CooldownsWindow = new(new(20, 20, 0, 0), "Cooldown Debugger", () =>
            {

                if (GUILayout.Button("Reset Full Cooldown"))
                    Utils.ResetCustomTimers();

                if (GUILayout.Button("Close Cooldowns Menu"))
                    CooldownsWindow.Enabled = false;
            })
            {
                Enabled = false
            };
        }

        public void Update()
        {
            if (ConstantVariables.NoPlayers || !ConstantVariables.IsLocalGame)
            {
                if (TestWindow.Enabled)
                    TestWindow.Enabled = false;

                if (CooldownsWindow.Enabled)
                    CooldownsWindow.Enabled = false;

                return; //You must ensure you are only playing on local
            }

            if (Input.GetKeyDown(KeyCode.F1))
            {
                TestWindow.Enabled = !TestWindow.Enabled;

                if (CooldownsWindow.Enabled && !TestWindow.Enabled)
                    CooldownsWindow.Enabled = false;

                if (!TestWindow.Enabled && ConstantVariables.IsLobby)
                {
                    MCIUtils.RemoveAllPlayers();
                    TownOfUs.MCIActive = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.F2) && ConstantVariables.IsInGame)
                CooldownsWindow.Enabled = !CooldownsWindow.Enabled;
        }

        public void OnGUI()
        {
            TestWindow.OnGUI();
            CooldownsWindow.OnGUI();
        }

        public void OnDestroy()
        {
            TestWindow.Enabled = false;
            CooldownsWindow.Enabled = false;
        }
    }
}