using TownOfUs.Extensions;

namespace TownOfUs.Roles
{
    public class Impostor : Role
    {
        public Impostor(PlayerControl player) : base(player)
        {
            Name = "Impostor";
            ImpostorText = () => Language.GetString("roles.vanilla.imp");
            TaskText = () => Language.GetString("roles.vanilla.imp");
            Faction = Faction.Impostors;
            RoleType = RoleEnum.Impostor;
            AddToRoleHistory(RoleType);
            Color = Palette.ImpostorRed;
        }
    }

    public class Crewmate : Role
    {
        public Crewmate(PlayerControl player) : base(player)
        {
            Name = "Crewmate";
            ImpostorText = () => Language.GetString("roles.vanilla.crew");
            TaskText = () => Language.GetString("roles.vanilla.crew");
            Faction = Faction.Crewmates;
            RoleType = RoleEnum.Crewmate;
            AddToRoleHistory(RoleType);
            Color = Patches.Colors.Crewmate;
        }
    }
}