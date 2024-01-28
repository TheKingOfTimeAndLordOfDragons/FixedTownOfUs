using TownOfUs.Extensions;

namespace TownOfUs.Roles.Modifiers
{
    public class Multitasker : Modifier
    {
        public Multitasker(PlayerControl player) : base(player)
        {
            Name = "Multitasker";
            TaskText = () => Language.GetString("roles.modifiers.multitasker");
            Color = Patches.Colors.Multitasker;
            ModifierType = ModifierEnum.Multitasker;
        }
    }
}