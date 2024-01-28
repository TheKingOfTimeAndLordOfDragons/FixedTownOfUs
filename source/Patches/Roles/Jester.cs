using Il2CppSystem.Collections.Generic;
using TownOfUs.Extensions;

namespace TownOfUs.Roles
{
    public class Jester : Role
    {
        public static bool VotedOut {get;set;} = false;
        public bool SpawnedAs = true;


        public Jester(PlayerControl player) : base(player)
        {
            Name = "Jester";
            ImpostorText = () => Language.GetString("roles.jester");
            TaskText = () => SpawnedAs ? Language.GetString("roles.jester") : Language.GetString("roles.jester.not");
            Color = Patches.Colors.Jester;
            RoleType = RoleEnum.Jester;
            AddToRoleHistory(RoleType);
            Faction = Faction.NeutralEvil;
        }
    }
}