using TownOfUs.Extensions;

namespace TownOfUs.Roles.Modifiers
{
    public class Blind : Modifier
    {
        public Blind(PlayerControl player) : base(player)
        {
            Name = "Blind";
            TaskText = () => Language.GetString("roles.modifiers.blind");
            Color = Patches.Colors.Blind;
            ModifierType = ModifierEnum.Blind;
        }
    }
}