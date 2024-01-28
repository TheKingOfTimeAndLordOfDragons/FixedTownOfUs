using System;
using System.Linq;
using TownOfUs.Extensions;

namespace TownOfUs.Roles
{
    public class Pestilence : Role
    {
        public Pestilence(PlayerControl owner) : base(owner)
        {
            Name = "Pestilence";
            Color = Patches.Colors.Pestilence;
            LastKill = DateTime.UtcNow;
            RoleType = RoleEnum.Pestilence;
            AddToRoleHistory(RoleType);
            ImpostorText = () => "";
            TaskText = () => Language.GetString("roles.pestilence");
            Faction = Faction.NeutralKilling;
        }

        public PlayerControl ClosestPlayer;
        public DateTime LastKill { get; set; }

        public float KillTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastKill;
            var num = CustomGameOptions.PestKillCd * 1000f;
            var flag2 = num - (float)timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float)timeSpan.TotalMilliseconds) / 1000f;
        }
    }
}