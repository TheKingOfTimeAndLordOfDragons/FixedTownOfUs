using Il2CppSystem.Collections.Generic;
using TownOfUs.Extensions;

namespace TownOfUs.Roles
{
    public class Executioner : Role
    {
        public PlayerControl target;
        public static bool TargetVotedOut {get;set;} = false;

        public Executioner(PlayerControl player) : base(player)
        {
            Name = "Executioner";
            ImpostorText = () =>
                target == null ? Language.GetString("roles.executioner") : Language.GetString("roles.executioner.target").Replace("%target%", target.name.ToString());
            TaskText = () =>
                target == null
                    ? Language.GetString("roles.executioner")
                    : Language.GetString("roles.executioner.target").Replace("%target%", target.name.ToString());
            Color = Patches.Colors.Executioner;
            RoleType = RoleEnum.Executioner;
            AddToRoleHistory(RoleType);
            Faction = Faction.NeutralEvil;
            Scale = 1.4f;
        }
    }
}