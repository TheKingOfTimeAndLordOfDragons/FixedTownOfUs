using HarmonyLib;
using System;

namespace TownOfUs.MCI
{
    [HarmonyPatch(typeof(SpawnInMinigame), nameof(SpawnInMinigame.Begin))]
    public sealed class AirshipSpawn
    {
        public static void Postfix(SpawnInMinigame __instance)
        {
            foreach (var player in PlayerControl.AllPlayerControls)
            {
                if (!player.Data.PlayerName.Contains("Bot"))
                    continue;

                var rand = new Random().Next(0, __instance.Locations.Count);
                player.gameObject.SetActive(true);
                player.NetTransform.RpcSnapTo(__instance.Locations[rand].Location);
            }
        }
    }

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

    [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.Confirm))]
    [HarmonyPriority(Priority.Last)]
    public sealed class SameVoteAll
    {
        public static void Postfix(MeetingHud __instance, ref byte suspectStateIdx)
        {
            if (!ConstantVariables.IsLocalGame || !TownOfUs.MCIActive)
                return;

            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
                __instance.CmdCastVote(player.PlayerId, suspectStateIdx);
        }
    }
}