namespace TownOfUs.Roles
{
    public class Impostor : Role
    {
        public Impostor(PlayerControl player) : base(player)
        {
            Name = "Impostor";
            ImpostorText = () => "Kill All Crewmates";
            TaskText = () => "Kill all crewmates";
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
            ImpostorText = () => "Do Your tasks And Find The Impostors";
            TaskText = () => "Do your tasks and find the Impostors";
            Faction = Faction.Crewmates;
            RoleType = RoleEnum.Crewmate;
            AddToRoleHistory(RoleType);
            Color = Patches.Colors.Crewmate;
        }
    }
}