using TownOfUs.Extensions;

namespace TownOfUs.Roles.Modifiers
{
    public class Drunk : Modifier
    {
        public Drunk(PlayerControl player) : base(player)
        {
            Name = "Drunk";
            TaskText = () => Language.GetString("roles.modifiers.drunk");
            Color = Patches.Colors.Drunk;
            ModifierType = ModifierEnum.Drunk;
        }
    }
}