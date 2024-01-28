using System;
using TownOfUs.Extensions;

namespace TownOfUs.Roles.Cultist
{
    public class Necromancer : Role
    {
        public DeadBody CurrentTarget;
        public KillButton _reviveButton;
        public DateTime LastRevived;
        public int ReviveCount;


        public Necromancer(PlayerControl player) : base(player)
        {
            Name = "Necromancer";
            ImpostorText = () => Language.GetString("roles.cultist.necromancer");
            TaskText = () => Language.GetString("roles.cultist.necromancer");
            Color = Patches.Colors.Impostor;
            LastRevived = DateTime.UtcNow;
            RoleType = RoleEnum.Necromancer;
            AddToRoleHistory(RoleType);
            Faction = Faction.Impostors;
        }

        public KillButton ReviveButton
        {
            get => _reviveButton;
            set
            {
                _reviveButton = value;
                ExtraButtons.Clear();
                ExtraButtons.Add(value);
            }
        }

        public float ReviveTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastRevived;
            var num = (CustomGameOptions.ReviveCooldown + CustomGameOptions.IncreasedCooldownPerRevive * ReviveCount) * 1000f;
            var flag2 = num - (float) timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float) timeSpan.TotalMilliseconds) / 1000f;
        }
    }
}