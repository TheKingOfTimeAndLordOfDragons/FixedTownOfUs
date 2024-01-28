using AmongUs.GameOptions;
using InnerNet;
using HarmonyLib;
using System.Linq;

namespace TownOfUs.MultiClientInstancing
{
    //Thanks to Town Of Host for this code
    [HarmonyPatch]
    public static class ConstantVariables
    {
        public static bool IsInGame => AmongUsClient.Instance.GameState == InnerNetClient.GameStates.Started && !LobbyBehaviour.Instance;
        public static bool IsLobby => AmongUsClient.Instance.GameState == InnerNetClient.GameStates.Joined || LobbyBehaviour.Instance;
        public static bool IsLocalGame => AmongUsClient.Instance.NetworkMode == NetworkModes.LocalGame;
    }
}