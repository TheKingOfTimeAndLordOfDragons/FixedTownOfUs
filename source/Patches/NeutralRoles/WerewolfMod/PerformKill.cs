﻿using System;
using HarmonyLib;
using TownOfUs.Roles;
using AmongUs.GameOptions;
using TownOfUs.Extensions;

namespace TownOfUs.NeutralRoles.WerewolfMod
{
    [HarmonyPatch(typeof(KillButton), nameof(KillButton.DoClick))]
    public class PerformKill
    {
        public static bool Prefix(KillButton __instance)
        {
            var flag = PlayerControl.LocalPlayer.Is(RoleEnum.Werewolf);
            if (!flag) return true;
            if (PlayerControl.LocalPlayer.Data.IsDead) return false;
            if (!PlayerControl.LocalPlayer.CanMove) return false;
            var role = Role.GetRole<Werewolf>(PlayerControl.LocalPlayer);
            if (role.Player.inVent) return false;

            if (__instance == role.RampageButton)
            {
                if (role.RampageTimer() != 0) return false;
                if (!__instance.isActiveAndEnabled || __instance.isCoolingDown) return false;

                role.TimeRemaining = CustomGameOptions.RampageDuration;
                role.Rampage();
                SoundEffectsManager.play("werewolfRampage");
                return false;
            }

            if (role.KillTimer() != 0) return false;
            if (!role.Rampaged) return false;
            if (__instance != DestroyableSingleton<HudManager>.Instance.KillButton) return true;
            if (!__instance.isActiveAndEnabled || __instance.isCoolingDown) return false;
            if (role.ClosestPlayer == null) return false;
            var distBetweenPlayers = Utils.GetDistBetweenPlayers(PlayerControl.LocalPlayer, role.ClosestPlayer);
            var flag3 = distBetweenPlayers <
                        GameOptionsData.KillDistances[GameOptionsManager.Instance.currentNormalGameOptions.KillDistance];
            if (!flag3) return false;

            var interact = Utils.Interact(PlayerControl.LocalPlayer, role.ClosestPlayer, true);
            if (interact.AbilityUsed) return false;
            else if (interact.FullCooldownReset)
            {
                role.LastKilled = DateTime.UtcNow;
                return false;
            }
            else if (interact.GaReset)
            {
                role.LastKilled = DateTime.UtcNow;
                role.LastKilled = role.LastKilled.AddSeconds(CustomGameOptions.ProtectKCReset - CustomGameOptions.RampageKillCd);
                return false;
            }
            else if (interact.SurvReset)
            {
                role.LastKilled = DateTime.UtcNow;
                role.LastKilled = role.LastKilled.AddSeconds(CustomGameOptions.VestKCReset - CustomGameOptions.RampageKillCd);
                return false;
            }
            else if (interact.ZeroSecReset) return false;
            return false;
        }
    }
}
