using TownOfUs.Extensions;

namespace TownOfUs.Roles
{
    public class Spy : Role
    {
        public Spy(PlayerControl player) : base(player)
        {
            Name = "Spy";
            ImpostorText = () => Language.GetString("roles.spy");
            TaskText = () => Language.GetString("roles.spy");
            Color = Patches.Colors.Spy;
            RoleType = RoleEnum.Spy;
            AddToRoleHistory(RoleType);
        }
    }
}