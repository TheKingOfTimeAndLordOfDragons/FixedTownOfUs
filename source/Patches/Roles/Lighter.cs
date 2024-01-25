using System;
using UnityEngine;

namespace TownOfUs.Roles
{
    public class Lighter : Role
    {
        public bool Enabled;
        public DateTime LastUsed { get; set; }
        public float TimeRemaining;
        public bool IsUsingLight => TimeRemaining > 0f;

        public Lighter(PlayerControl player) : base(player)
        {
            Name = "Lighter";
            ImpostorText = () => "Need a light?";
            TaskText = () => "Use your lighter for extra visibility.";
            Color = Patches.Colors.Lighter;
            LastUsed = DateTime.UtcNow;
            RoleType = RoleEnum.Lighter;
            AddToRoleHistory(RoleType);
        }

        public float LightTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastUsed;
            var num = CustomGameOptions.LighterCooldown * 1000f;
            var flag2 = num - (float) timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float) timeSpan.TotalMilliseconds) / 1000f;
        }

        public void Light()
        {
            Enabled = true;
            TimeRemaining -= Time.deltaTime;
        }


        public void UnLight()
        {
            Enabled = false;
            LastUsed = DateTime.UtcNow;
        }
    }
}