using TownOfUs.Extensions;

namespace TownOfUs.Roles.Modifiers
{
    public class Torch : Modifier
    {
        public Torch(PlayerControl player) : base(player)
        {
            Name = "Torch";
            TaskText = () => Language.GetString("roles.modifiers.torch");
            Color = Patches.Colors.Torch;
            ModifierType = ModifierEnum.Torch;
        }
    }
}