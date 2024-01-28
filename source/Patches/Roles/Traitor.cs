using TownOfUs.Extensions;

namespace TownOfUs.Roles
{
    public class Traitor : Role
    {
        public RoleEnum formerRole = new RoleEnum();
        public Traitor(PlayerControl player) : base(player)
        {
            Name = "Traitor";
            ImpostorText = () => "";
            TaskText = () => Language.GetString("roles.traitor");
            Color = Patches.Colors.Impostor;
            RoleType = RoleEnum.Traitor;
            AddToRoleHistory(RoleType);
            Faction = Faction.Impostors;
        }
    }
}