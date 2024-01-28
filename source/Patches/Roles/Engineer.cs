using TMPro;
using TownOfUs.Extensions;

namespace TownOfUs.Roles
{
    public class Engineer : Role
    {
        public Engineer(PlayerControl player) : base(player)
        {
            Name = "Engineer";
            ImpostorText = () => CustomGameOptions.GameMode == GameMode.Cultist ? Language.GetString("roles.engineer.cultist") : Language.GetString("roles.engineer");
            TaskText = () => CustomGameOptions.GameMode == GameMode.Cultist ? Language.GetString("roles.engineer.cultist") : Language.GetString("roles.engineer");
            Color = Patches.Colors.Engineer;
            RoleType = RoleEnum.Engineer;
            AddToRoleHistory(RoleType);
            UsesLeft = CustomGameOptions.MaxFixes;
        }

        public int UsesLeft;
        public TextMeshPro UsesText;

        public bool ButtonUsable => UsesLeft != 0;
    }
}