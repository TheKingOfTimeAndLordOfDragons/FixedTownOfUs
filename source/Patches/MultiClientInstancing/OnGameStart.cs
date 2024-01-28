using HarmonyLib;

namespace TownOfUs.MultiClientInstancing
{
    [HarmonyPatch(typeof(AmongUsClient), nameof(AmongUsClient.CoStartGameHost))]
    public sealed class OnGameStart
    {
        public static void Prefix(AmongUsClient __instance)
        {
            if (TownOfUs.MCIActive)
            {
                foreach (var p in __instance.allClients)
                    p.IsReady = true;
            }
        }
    }
}