using System;
using TownOfUs.Extensions;
using TownOfUs.Roles;

namespace TownOfUs.CrewmateRoles.DetectiveMod
{
    public class BodyReport
    {
        public PlayerControl Killer { get; set; }
        public PlayerControl Reporter { get; set; }
        public PlayerControl Body { get; set; }
        public float KillAge { get; set; }

        public static string ParseBodyReport(BodyReport br)
        {
            if (br.KillAge > CustomGameOptions.DetectiveFactionDuration * 1000)
                return
                    Language.GetString("roles.crewmate.detective.report.old").Replace("%time%", (Math.Round(br.KillAge / 1000).ToString()));

            if (br.Killer.PlayerId == br.Body.PlayerId)
                return
                    Language.GetString("roles.crewmate.detective.report.suicide").Replace("%time%", (Math.Round(br.KillAge / 1000).ToString()));

            var role = Role.GetRole(br.Killer);

            if (br.KillAge < CustomGameOptions.DetectiveRoleDuration * 1000)
                return
                    Language.GetString("roles.crewmate.detective.report.name").Replace("%role%", role.Name.ToString()).Replace("%time%", (Math.Round(br.KillAge / 1000).ToString()));

            if (br.Killer.Is(Faction.Crewmates))
                return
                    Language.GetString("roles.crewmate.detective.report.crew").Replace("%time%", (Math.Round(br.KillAge / 1000).ToString()));

            else if (br.Killer.Is(Faction.NeutralKilling) || br.Killer.Is(Faction.NeutralBenign))
                return
                    Language.GetString("roles.crewmate.detective.report.neut").Replace("%time%", (Math.Round(br.KillAge / 1000).ToString()));

            else
                return
                    Language.GetString("roles.crewmate.detective.report.imp").Replace("%time%", (Math.Round(br.KillAge / 1000).ToString()));
        }
    }
}
