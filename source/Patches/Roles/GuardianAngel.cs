using System;
using UnityEngine;
using TMPro;
using TownOfUs.Extensions;

namespace TownOfUs.Roles
{
    public class GuardianAngel : Role
    {
        public bool Enabled;
        public DateTime LastProtected;
        public float TimeRemaining;

        public int UsesLeft;
        public TextMeshPro UsesText;

        public bool ButtonUsable => UsesLeft != 0;

        public PlayerControl target;

        public GuardianAngel(PlayerControl player) : base(player)
        {
            Name = "Guardian Angel";
            ImpostorText = () =>
                target == null ? Language.GetString("roles.ga") : Language.GetString("roles.ga.target").Replace("%target%", target.name.ToString());
            TaskText = () =>
                target == null
                    ? Language.GetString("roles.ga")
                    : Language.GetString("roles.ga.target").Replace("%target%", target.name.ToString());
            Color = Patches.Colors.GuardianAngel;
            LastProtected = DateTime.UtcNow;
            RoleType = RoleEnum.GuardianAngel;
            AddToRoleHistory(RoleType);
            Faction = Faction.NeutralBenign;
            Scale = 1.4f;

            UsesLeft = CustomGameOptions.MaxProtects;
        }

        public bool Protecting => TimeRemaining > 0f;

        public float ProtectTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastProtected;
            var num = CustomGameOptions.ProtectCd * 1000f;
            var flag2 = num - (float)timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float)timeSpan.TotalMilliseconds) / 1000f;
        }

        public void Protect()
        {
            Enabled = true;
            TimeRemaining -= Time.deltaTime;
        }


        public void UnProtect()
        {
            var ga = GetRole<GuardianAngel>(Player);
            if (!ga.target.IsShielded())
            {
                ga.target.myRend().material.SetColor("_VisorColor", Palette.VisorColor);
                ga.target.myRend().material.SetFloat("_Outline", 0f);
            }
            Enabled = false;
            LastProtected = DateTime.UtcNow;
        }
    }
}