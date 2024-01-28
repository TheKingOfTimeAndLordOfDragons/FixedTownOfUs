using System;
using TownOfUs.Extensions;
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
            ImpostorText = () => Language.GetString("roles.lighter");
            TaskText = () => Language.GetString("roles.lighter");
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