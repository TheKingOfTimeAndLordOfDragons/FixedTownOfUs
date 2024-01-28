using System.Collections.Generic;
using TownOfUs.Extensions;

namespace TownOfUs.Roles.Modifiers
{
    public class Radar : Modifier
    {
        public List<ArrowBehaviour> RadarArrow = new List<ArrowBehaviour>();
        public PlayerControl ClosestPlayer;
        public Radar(PlayerControl player) : base(player)
        {
            Name = "Radar";
            TaskText = () => Language.GetString("roles.modifiers.radar");
            Color = Patches.Colors.Radar;
            ModifierType = ModifierEnum.Radar;
        }
    }
}