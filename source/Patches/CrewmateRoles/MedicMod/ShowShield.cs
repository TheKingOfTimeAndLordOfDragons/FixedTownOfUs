using HarmonyLib;
using TownOfUs.Extensions;
using TownOfUs.Roles;
using UnityEngine;

namespace TownOfUs.CrewmateRoles.MedicMod
{
    public enum ShieldOptions
    {
        Self = 0,
        Medic = 1,
        SelfAndMedic = 2,
        Everyone = 3
    }

    public enum NotificationOptions
    {
        Medic = 0,
        Shielded = 1,
        Everyone = 2,
        Nobody = 3
    }

    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public class ShowShield
    {
        public static Color ProtectedColor = Color.cyan;

        public static void Postfix(HudManager __instance)
        {
            foreach (var role in Role.GetRoles(RoleEnum.Medic))
            {
                var medic = (Medic) role;

                var exPlayer = medic.exShielded;
                if (exPlayer != null)
                {
                    exPlayer.myRend().material.SetColor("_VisorColor", Palette.VisorColor);
                    exPlayer.myRend().material.SetFloat("_Outline", 0f);
                    medic.exShielded = null;
                    continue;
                }

                var player = medic.ShieldedPlayer;
                if (player == null) continue;

                if (player.Data.IsDead || medic.Player.Data.IsDead || medic.Player.Data.Disconnected)
                {
                    StopKill.BreakShield(medic.Player.PlayerId, player.PlayerId, true);
                    continue;
                }
            }
        }
    }
}