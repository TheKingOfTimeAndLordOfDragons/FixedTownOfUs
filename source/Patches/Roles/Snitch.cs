using System.Collections.Generic;
using TownOfUs.Extensions;
using UnityEngine;
using System.Linq;

namespace TownOfUs.Roles
{
    public class Snitch : Role
    {
        public List<ArrowBehaviour> ImpArrows = new List<ArrowBehaviour>();

        public Dictionary<byte, ArrowBehaviour> SnitchArrows = new Dictionary<byte, ArrowBehaviour>();

        public Snitch(PlayerControl player) : base(player)
        {
            Name = "Snitch";
            ImpostorText = () => Language.GetString("roles.snitch");
            TaskText = () =>
                TasksDone
                    ? Language.GetString("roles.snitch.arrows")
                    : Language.GetString("roles.snitch");
            Color = Patches.Colors.Snitch;
            RoleType = RoleEnum.Snitch;
            AddToRoleHistory(RoleType);
        }

        public bool Revealed => TasksLeft <= CustomGameOptions.SnitchTasksRemaining;
        public bool TasksDone => TasksLeft <= 0;

        internal override bool Criteria()
        {
            return Revealed && PlayerControl.LocalPlayer.Data.IsImpostor() && !Player.Data.IsDead ||
                   base.Criteria();
        }

        internal override bool RoleCriteria()
        {
            var localPlayer = PlayerControl.LocalPlayer;
            if (localPlayer.Data.IsImpostor() && !Player.Data.IsDead)
            {
                return Revealed || base.RoleCriteria();
            }
            else if (GetRole(localPlayer).Faction == Faction.NeutralKilling && !Player.Data.IsDead)
            {
                return Revealed && CustomGameOptions.SnitchSeesNeutrals || base.RoleCriteria();
            }
            return false || base.RoleCriteria();
        }

        public void DestroyArrow(byte targetPlayerId)
        {
            var arrow = SnitchArrows.FirstOrDefault(x => x.Key == targetPlayerId);
            if (arrow.Value != null)
                Object.Destroy(arrow.Value);
            if (arrow.Value.gameObject != null)
                Object.Destroy(arrow.Value.gameObject);
            SnitchArrows.Remove(arrow.Key);
        }
    }
}