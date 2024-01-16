using AmongUs.GameOptions;
using HarmonyLib;
using InnerNet;
using TownOfUs.Roles;
using TownOfUs.Roles.Modifiers;

namespace TownOfUs.MCI
{
    //Thanks to Town Of Host for this code
    [HarmonyPatch]
    public static class ConstantVariables
    {
        public static bool IsCountDown => GameStartManager.Instance && GameStartManager.Instance.startState == GameStartManager.StartingStates.Countdown;
        public static bool IsInGame => AmongUsClient.Instance.GameState == InnerNetClient.GameStates.Started && !LobbyBehaviour.Instance;
        public static bool IsLobby => AmongUsClient.Instance.GameState == InnerNetClient.GameStates.Joined || LobbyBehaviour.Instance;
        public static bool IsEnded => AmongUsClient.Instance.GameState == InnerNetClient.GameStates.Ended;
        public static bool IsHnS => GameOptionsManager.Instance.CurrentGameOptions.GameMode == GameModes.HideNSeek;
        public static bool IsNormal => GameOptionsManager.Instance.CurrentGameOptions.GameMode == GameModes.Normal;
        public static bool IsOnlineGame => AmongUsClient.Instance.NetworkMode == NetworkModes.OnlineGame;
        public static bool IsLocalGame => AmongUsClient.Instance.NetworkMode == NetworkModes.LocalGame;
        public static bool IsFreePlay => AmongUsClient.Instance.NetworkMode == NetworkModes.FreePlay;
        public static bool IsRoaming => IsInGame && !MeetingHud.Instance && !Minigame.Instance;
        public static bool IsMeeting => IsInGame && MeetingHud.Instance;
        public static bool NoLobby => !(IsInGame || IsLobby || IsEnded || IsRoaming || IsMeeting);
        public static bool NoPlayers => PlayerControl.AllPlayerControls.Count < 1 || PlayerControl.LocalPlayer == null || PlayerControl.LocalPlayer.Data == null || NoLobby;
        public static bool GameHasEnded => Role.NobodyWins || Role.VampireWins || Role.SurvOnlyWins;
    }
}