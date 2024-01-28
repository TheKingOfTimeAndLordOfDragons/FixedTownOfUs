using TownOfUs.Extensions;

namespace TownOfUs.Roles.Modifiers
{
    public class Diseased : Modifier
    {
        public Diseased(PlayerControl player) : base(player)
        {
            Name = "Diseased";
            TaskText = () => Language.GetString("roles.modifiers.diseased");
            Color = Patches.Colors.Diseased;
            ModifierType = ModifierEnum.Diseased;
        }
    }
}