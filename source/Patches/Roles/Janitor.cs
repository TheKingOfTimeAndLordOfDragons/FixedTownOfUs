using TownOfUs.Extensions;

namespace TownOfUs.Roles
{
    public class Janitor : Role
    {
        public KillButton _cleanButton;

        public Janitor(PlayerControl player) : base(player)
        {
            Name = "Janitor";
            ImpostorText = () => Language.GetString("roles.janitor");
            TaskText = () => Language.GetString("roles.janitor");
            Color = Patches.Colors.Impostor;
            RoleType = RoleEnum.Janitor;
            AddToRoleHistory(RoleType);
            Faction = Faction.Impostors;
        }

        public DeadBody CurrentTarget { get; set; }

        public KillButton CleanButton
        {
            get => _cleanButton;
            set
            {
                _cleanButton = value;
                ExtraButtons.Clear();
                ExtraButtons.Add(value);
            }
        }
    }
}