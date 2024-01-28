using TownOfUs.Extensions;

namespace TownOfUs.Roles.Cultist
{
    public class CultistSnitch : Role
    {
        public bool CompletedTasks;
        public PlayerControl RevealedPlayer;
        public CultistSnitch(PlayerControl player) : base(player)
        {
            Name = "Snitch";
            ImpostorText = () => Language.GetString("roles.cultist.snitch");
            TaskText = () => Language.GetString("roles.cultist.snitch");
            Color = Patches.Colors.Snitch;
            RoleType = RoleEnum.CultistSnitch;
            AddToRoleHistory(RoleType);
        }
    }
}