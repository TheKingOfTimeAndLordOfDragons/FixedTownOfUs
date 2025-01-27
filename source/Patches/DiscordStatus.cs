﻿using Discord;
using HarmonyLib;
namespace TownOfUs.Patches
{
    internal class DiscordStatus
    {
        [HarmonyPatch(typeof(ActivityManager), nameof(ActivityManager.UpdateActivity))]
        [HarmonyPrefix]
        public static void Prefix([HarmonyArgument(0)] Activity activity)
        {
            activity.Details += $" Fixed Town of Us v{TownOfUs.VersionString}";
        }
    }
}
