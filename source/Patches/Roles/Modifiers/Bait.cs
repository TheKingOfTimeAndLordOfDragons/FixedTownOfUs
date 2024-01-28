using TownOfUs.Extensions;

namespace TownOfUs.Roles.Modifiers
{
    public class Bait : Modifier
    {
        public Bait(PlayerControl player) : base(player)
        {
            Name = "Bait";
            TaskText = () => Language.GetString("roles.modifiers.bait");
            Color = Patches.Colors.Bait;
            ModifierType = ModifierEnum.Bait;
        }
    }
}