using HarmonyLib;
using TownOfUs.Extensions;
using TownOfUs.Roles;

namespace TownOfUs.CrewmateRoles.OracleMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public class HighlightConfessor
    {
        public static void UpdateMeeting(Oracle role, MeetingHud __instance)
        {
            foreach (var player in PlayerControl.AllPlayerControls)
            {
                foreach (var state in __instance.playerStates)
                {
                    if (player.PlayerId != state.TargetPlayerId) continue;
                    if (player == role.Confessor)
                    {
                        if (role.RevealedFaction == Faction.Crewmates) state.NameText.text = "<color=#00FFFFFF>" + Language.GetString("roles.crewmate.oracle.crew") + " </color>" + state.NameText.text;
                        else if (role.RevealedFaction == Faction.Impostors) state.NameText.text = "<color=#FF0000FF>" + Language.GetString("roles.crewmate.oracle.imp") + " </color>" + state.NameText.text;
                        else state.NameText.text = "<color=#808080FF>" + Language.GetString("roles.crewmate.oracle.neut") + " </color>" + state.NameText.text;
                    }
                }
            }
        }
        public static void Postfix(HudManager __instance)
        {
            if (!MeetingHud.Instance || PlayerControl.LocalPlayer.Data.IsDead) return;
            foreach (var oracle in Role.GetRoles(RoleEnum.Oracle))
            {
                var role = Role.GetRole<Oracle>(oracle.Player);
                if (!role.Player.Data.IsDead || role.Confessor == null) return;
                UpdateMeeting(role, MeetingHud.Instance);
            }
        }
    }
}