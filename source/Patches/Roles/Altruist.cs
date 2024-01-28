using TownOfUs.Extensions;

namespace TownOfUs.Roles
{
    public class Altruist : Role
    {
        public bool CurrentlyReviving;
        public DeadBody CurrentTarget;

        public bool ReviveUsed;
        
        public Altruist(PlayerControl player) : base(player)
        {
            Name = "Altruist";
            ImpostorText = () => Language.GetString("roles.altruist");
            TaskText = () => Language.GetString("roles.altruist");
            Color = Patches.Colors.Altruist;
            RoleType = RoleEnum.Altruist;
            AddToRoleHistory(RoleType);
        }
    }
}