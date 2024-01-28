using TownOfUs.Extensions;

namespace TownOfUs.Roles.Modifiers
{
    public class Tiebreaker : Modifier
    {
        public Tiebreaker(PlayerControl player) : base(player)
        {
            Name = "Tiebreaker";
            TaskText = () => Language.GetString("roles.modifiers.tiebreaker");
            Color = Patches.Colors.Tiebreaker;
            ModifierType = ModifierEnum.Tiebreaker;
        }
    }
}