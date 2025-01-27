using HarmonyLib;
using Reactor.Utilities;
using TownOfUs.Extensions;
using TownOfUs.Roles;
using UnityEngine;

namespace TownOfUs.CrewmateRoles.MedicMod
{
    [HarmonyPatch(typeof(KillButton), nameof(KillButton.DoClick))]
    public class StopKill
    {
        public static void BreakShield(byte medicId, byte playerId, bool flag)
        {
            if (PlayerControl.LocalPlayer.PlayerId == playerId && CustomGameOptions.NotificationShield == NotificationOptions.Shielded) 
            {
                Coroutines.Start(Utils.FlashCoroutine(new Color(0f, 0.5f, 0f, 1f)));
                SoundEffectsManager.play("murderAttempt");
            }

            if (PlayerControl.LocalPlayer.PlayerId == medicId && CustomGameOptions.NotificationShield == NotificationOptions.Medic) 
            {
                Coroutines.Start(Utils.FlashCoroutine(new Color(0f, 0.5f, 0f, 1f)));
                SoundEffectsManager.play("murderAttempt");
            }

            if (CustomGameOptions.NotificationShield == NotificationOptions.Everyone) 
            {
                Coroutines.Start(Utils.FlashCoroutine(new Color(0f, 0.5f, 0f, 1f)));
                SoundEffectsManager.play("murderAttempt");
            }

            if (!flag)
                return;

            var player = Utils.PlayerById(playerId);
            foreach (var role in Role.GetRoles(RoleEnum.Medic))
                if (((Medic) role).ShieldedPlayer.PlayerId == playerId)
                {
                    ((Medic) role).ShieldedPlayer = null;
                    ((Medic) role).exShielded = player;
                }

            player.myRend().material.SetColor("_VisorColor", Palette.VisorColor);
            player.myRend().material.SetFloat("_Outline", 0f);
        }
    }
}