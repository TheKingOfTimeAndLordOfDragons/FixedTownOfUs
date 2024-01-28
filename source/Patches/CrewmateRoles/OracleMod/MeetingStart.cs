using HarmonyLib;
using System.Linq;
using TownOfUs.Extensions;
using TownOfUs.Roles;

namespace TownOfUs.CrewmateRoles.OracleMod
{
    [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.Start))]
    public class MeetingStartOracle
    {
        public static void Postfix(MeetingHud __instance)
        {
            if (PlayerControl.LocalPlayer.Data.IsDead) return;
            if (!PlayerControl.LocalPlayer.Is(RoleEnum.Oracle)) return;
            var oracleRole = Role.GetRole<Oracle>(PlayerControl.LocalPlayer);
            if (oracleRole.Confessor != null)
            {
                var playerResults = PlayerReportFeedback(oracleRole.Confessor);

                if (!string.IsNullOrWhiteSpace(playerResults)) DestroyableSingleton<HudManager>.Instance.Chat.AddChat(PlayerControl.LocalPlayer, playerResults);
            }
        }

        public static string PlayerReportFeedback(PlayerControl player)
        {
            if (player.Data.IsDead || player.Data.Disconnected) return Language.GetString("roles.crewmate.oracle.fail");
            var allPlayers = PlayerControl.AllPlayerControls.ToArray().Where(x => !x.Data.IsDead && !x.Data.Disconnected && x != PlayerControl.LocalPlayer && x != player).ToList();
            if (allPlayers.Count < 2) return Language.GetString("roles.crewmate.oracle.few");
            var evilPlayers = PlayerControl.AllPlayerControls.ToArray().Where(x => !x.Data.IsDead && !x.Data.Disconnected &&
            (x.Is(Faction.Impostors) || (x.Is(Faction.NeutralKilling) && CustomGameOptions.NeutralKillingShowsEvil) ||
            (x.Is(Faction.NeutralEvil) && CustomGameOptions.NeutralEvilShowsEvil) || (x.Is(Faction.NeutralBenign) && CustomGameOptions.NeutralBenignShowsEvil))).ToList();
            if (evilPlayers.Count == 0) return Language.GetString("roles.crewmate.oracle.noevil").Replace("%player%", player.GetDefaultOutfit().PlayerName.ToString()); 
            allPlayers.Shuffle();
            evilPlayers.Shuffle();
            var secondPlayer = allPlayers[0];
            var firstTwoEvil = false;
            foreach (var evilPlayer in evilPlayers)
            {
                if (evilPlayer == player || evilPlayer == secondPlayer) firstTwoEvil = true;
            }
            if (firstTwoEvil)
            {
                var thirdPlayer = allPlayers[1];
                return Language.GetString("roles.crewmate.oracle.confess").Replace("%player%", player.GetDefaultOutfit().PlayerName.ToString()).Replace("%second%", secondPlayer.GetDefaultOutfit().PlayerName.ToString()).Replace("%third%", thirdPlayer.GetDefaultOutfit().PlayerName.ToString());
            }
            else
            {
                var thirdPlayer = evilPlayers[0];
                return Language.GetString("roles.crewmate.oracle.confess").Replace("%player%", player.GetDefaultOutfit().PlayerName.ToString()).Replace("%second%", secondPlayer.GetDefaultOutfit().PlayerName.ToString()).Replace("%third%", thirdPlayer.GetDefaultOutfit().PlayerName.ToString());
            }
        }
    }
}