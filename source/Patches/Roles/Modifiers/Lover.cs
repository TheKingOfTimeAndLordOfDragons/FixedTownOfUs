using System.Collections.Generic;
using System.Linq;
using TownOfUs.Patches;
using UnityEngine;
using TownOfUs.Extensions;

namespace TownOfUs.Roles.Modifiers
{
    public class Lover : Modifier
    {
        public Lover(PlayerControl player) : base(player)
        {
            Name = "Lover";
            SymbolName = "♥";
            TaskText = () =>
                "You are in Love with " + OtherLover.Player.GetDefaultOutfit().PlayerName;
            Color = Colors.Lovers;
            ModifierType = ModifierEnum.Lover;
        }

        public Lover OtherLover { get; set; }
        public bool LoveCoupleWins { get; set; }
        public int Num { get; set; }

        public override List<PlayerControl> GetTeammates()
        {
            var loverTeam = new List<PlayerControl>
            {
                PlayerControl.LocalPlayer,
                OtherLover.Player
            };
            return loverTeam;
        }

        public static void Gen(List<PlayerControl> canHaveModifiers)
        {
            List<PlayerControl> crewmates = new List<PlayerControl>();
            List<PlayerControl> impostors = new List<PlayerControl>();

            foreach(var player in canHaveModifiers)
            {
                if (player.Is(Faction.Impostors) || (player.Is(Faction.NeutralKilling) && !player.Is(RoleEnum.Vampire) && CustomGameOptions.NeutralLovers))
                    impostors.Add(player);
                else if (player.Is(Faction.Crewmates) || (player.Is(Faction.NeutralBenign) && CustomGameOptions.NeutralLovers)
                     || (player.Is(Faction.NeutralEvil) && CustomGameOptions.NeutralLovers))
                    crewmates.Add(player);
            }

            if (crewmates.Count < 2 || impostors.Count < 1) return;

            var num = Random.RandomRangeInt(0, crewmates.Count);
            var firstLover = crewmates[num];
            canHaveModifiers.Remove(firstLover);

            var lovingimp = Random.RandomRangeInt(0, 100);

            PlayerControl secondLover;
            if (CustomGameOptions.LovingImpPercent > lovingimp)
            {
                var num3 = Random.RandomRangeInt(0, impostors.Count);
                secondLover = impostors[num3];
            }
            else
            {
                var num3 = Random.RandomRangeInt(0, crewmates.Count);
                while (num3 == num)
                {
                    num3 = Random.RandomRangeInt(0, crewmates.Count);
                }
                secondLover = crewmates[num3];
            }
            canHaveModifiers.Remove(secondLover);

            Utils.Rpc(CustomRPC.SetCouple, firstLover.PlayerId, secondLover.PlayerId);
            var lover1 = new Lover(firstLover);
            var lover2 = new Lover(secondLover);

            lover1.OtherLover = lover2;
            lover2.OtherLover = lover1;
        }

        public static bool existing() {
            bool existing = false;
            foreach (var modifier in Modifier.GetModifiers(ModifierEnum.Lover))
            {
                var lover = (Lover)modifier;
                existing = lover.Player != null && lover.OtherLover.Player != null && !lover.Player.Data.Disconnected && !lover.OtherLover.Player.Data.Disconnected;
            }
            return existing;
        }

        public static bool existingAndAlive() {
            bool existingAndAlive = false;
            foreach (var modifier in Modifier.GetModifiers(ModifierEnum.Lover))
            {
                var lover = (Lover)modifier;
                existingAndAlive = existing() && !lover.Player.Data.IsDead && !lover.OtherLover.Player.Data.IsDead;
            }
            return existingAndAlive;
        }

        public static PlayerControl otherLover(PlayerControl oneLover) {
            if (!existingAndAlive()) return null;
            foreach (var modifier in Modifier.GetModifiers(ModifierEnum.Lover))
            {
                var lover = (Lover)modifier;
                if (oneLover == lover.Player) return lover.OtherLover.Player;
                if (oneLover == lover.OtherLover.Player) return lover.Player;
            }
            return null;
        }

        public static bool existingWithKiller() {
            bool existingWithKiller = false;
            foreach (var modifier in Modifier.GetModifiers(ModifierEnum.Lover))
            {
                var lover = (Lover)modifier;
                existingWithKiller = existing() && (lover.Player.Is(Faction.Impostors) || lover.Player.Is(Faction.NeutralKilling) || lover.OtherLover.Player.Is(Faction.Impostors) || lover.OtherLover.Player.Is(Faction.NeutralKilling));
            }
            return existingWithKiller;
        }
    }
}