using System.Collections.Generic;
using TownOfUs.Extensions;

namespace TownOfUs.Roles.Modifiers
{
    public class Sleuth : Modifier
    {
        public List<byte> Reported = new List<byte>();
        public Sleuth(PlayerControl player) : base(player)
        {
            Name = "Sleuth";
            TaskText = () => Language.GetString("roles.modifiers.sleuth");
            Color = Patches.Colors.Sleuth;
            ModifierType = ModifierEnum.Sleuth;
        }
    }
}