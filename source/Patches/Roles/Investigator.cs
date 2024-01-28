using System.Collections.Generic;
using TownOfUs.CrewmateRoles.InvestigatorMod;
using TownOfUs.Extensions;

namespace TownOfUs.Roles
{
    public class Investigator : Role
    {
        public readonly List<Footprint> AllPrints = new List<Footprint>();


        public Investigator(PlayerControl player) : base(player)
        {
            Name = "Investigator";
            ImpostorText = () => Language.GetString("roles.investigator");
            TaskText = () => Language.GetString("roles.investigator");
            Color = Patches.Colors.Investigator;
            RoleType = RoleEnum.Investigator;
            AddToRoleHistory(RoleType);
            Scale = 1.4f;
        }
    }
}