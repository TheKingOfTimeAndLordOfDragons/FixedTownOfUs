using System;
using System.Collections.Generic;
using TownOfUs.Extensions;

namespace TownOfUs.CrewmateRoles.MedicMod
{
    public class DeadPlayer
    {
        public byte KillerId { get; set; }
        public byte PlayerId { get; set; }
        public DateTime KillTime { get; set; }
    }

    //body report class for when medic reports a body
    public class BodyReport
    {
        public PlayerControl Killer { get; set; }
        public PlayerControl Reporter { get; set; }
        public PlayerControl Body { get; set; }
        public float KillAge { get; set; }

        public static string ParseBodyReport(BodyReport br)
        {
            //System.Console.WriteLine(br.KillAge);
            if (br.KillAge > CustomGameOptions.MedicReportColorDuration * 1000)
                return
                    Language.GetString("roles.crewmate.medic.report.old").Replace("%time%", (Math.Round(br.KillAge / 1000)).ToString());

            if (br.Killer.PlayerId == br.Body.PlayerId)
                return
                    Language.GetString("roles.crewmate.medic.report.suicide").Replace("%time%", (Math.Round(br.KillAge / 1000)).ToString());

            if (br.KillAge < CustomGameOptions.MedicReportNameDuration * 1000)
                return
                    Language.GetString("roles.crewmate.medic.report.name").Replace("%name%", br.Killer.Data.PlayerName.ToString()).Replace("%time%", (Math.Round(br.KillAge / 1000)).ToString());

            var colors = new Dictionary<int, string>
            {
                {0, Language.GetString("roles.crewmate.medic.darker")},// red
                {1, Language.GetString("roles.crewmate.medic.darker")},// blue
                {2, Language.GetString("roles.crewmate.medic.darker")},// green
                {3, Language.GetString("roles.crewmate.medic.lighter")},// pink
                {4, Language.GetString("roles.crewmate.medic.lighter")},// orange
                {5, Language.GetString("roles.crewmate.medic.lighter")},// yellow
                {6, Language.GetString("roles.crewmate.medic.darker")},// black
                {7, Language.GetString("roles.crewmate.medic.lighter")},// white
                {8, Language.GetString("roles.crewmate.medic.darker")},// purple
                {9, Language.GetString("roles.crewmate.medic.darker")},// brown
                {10, Language.GetString("roles.crewmate.medic.lighter")},// cyan
                {11, Language.GetString("roles.crewmate.medic.lighter")},// lime
                {12, Language.GetString("roles.crewmate.medic.darker")},// maroon
                {13, Language.GetString("roles.crewmate.medic.lighter")},// rose
                {14, Language.GetString("roles.crewmate.medic.lighter")},// banana
                {15, Language.GetString("roles.crewmate.medic.darker")},// gray
                {16, Language.GetString("roles.crewmate.medic.darker")},// tan
                {17, Language.GetString("roles.crewmate.medic.lighter")},// coral
                {18, Language.GetString("roles.crewmate.medic.darker")},// watermelon
                {19, Language.GetString("roles.crewmate.medic.darker")},// chocolate
                {20, Language.GetString("roles.crewmate.medic.lighter")},// sky blue
                {21, Language.GetString("roles.crewmate.medic.lighter")},// beige
                {22, Language.GetString("roles.crewmate.medic.darker")},// magenta
                {23, Language.GetString("roles.crewmate.medic.lighter")},// turquoise
                {24, Language.GetString("roles.crewmate.medic.lighter")},// lilac
                {25, Language.GetString("roles.crewmate.medic.darker")},// olive
                {26, Language.GetString("roles.crewmate.medic.lighter")},// azure
                {27, Language.GetString("roles.crewmate.medic.darker")},// plum
                {28, Language.GetString("roles.crewmate.medic.darker")},// jungle
                {29, Language.GetString("roles.crewmate.medic.lighter")},// mint
                {30, Language.GetString("roles.crewmate.medic.lighter")},// chartreuse
                {31, Language.GetString("roles.crewmate.medic.darker")},// macau
                {32, Language.GetString("roles.crewmate.medic.darker")},// tawny
                {33, Language.GetString("roles.crewmate.medic.lighter")},// gold
                {34, Language.GetString("roles.crewmate.medic.lighter")},// rainbow
            };
            var typeOfColor = colors[br.Killer.GetDefaultOutfit().ColorId];
            return
                Language.GetString("roles.crewmate.medic.report.color").Replace("%color%", typeOfColor.ToString()).Replace("%time%", (Math.Round(br.KillAge / 1000)).ToString());
        }
    }
}
