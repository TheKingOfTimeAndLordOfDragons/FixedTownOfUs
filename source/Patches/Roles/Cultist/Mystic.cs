using TownOfUs.Extensions;

namespace TownOfUs.Roles.Cultist
{
    public class CultistMystic : Role
    {
        public CultistMystic(PlayerControl player) : base(player)
        {
            Name = "Mystic";
            ImpostorText = () => Language.GetString("roles.cultist.mystic");
            TaskText = () => Language.GetString("roles.cultist.mystic");
            Color = Patches.Colors.Mystic;
            RoleType = RoleEnum.CultistMystic;
            AddToRoleHistory(RoleType);
        }
    }
}