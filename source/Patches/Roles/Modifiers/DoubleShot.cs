using TownOfUs.Extensions;

namespace TownOfUs.Roles.Modifiers
{
    public class DoubleShot : Modifier
    {
        public bool LifeUsed;
        public DoubleShot(PlayerControl player) : base(player)
        {
            Name = "Double Shot";
            TaskText = () => Language.GetString("roles.modifiers.double");
            Color = Patches.Colors.Impostor;
            ModifierType = ModifierEnum.DoubleShot;
            LifeUsed = false;
        }
    }
}