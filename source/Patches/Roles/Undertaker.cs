using System;
using TownOfUs.Extensions;

namespace TownOfUs.Roles
{
    public class Undertaker : Role
    {
        public KillButton _dragDropButton;

        public Undertaker(PlayerControl player) : base(player)
        {
            Name = "Undertaker";
            ImpostorText = () => Language.GetString("roles.undertaker");
            TaskText = () => Language.GetString("roles.undertaker");
            Color = Patches.Colors.Impostor;
            LastDragged = DateTime.UtcNow;
            RoleType = RoleEnum.Undertaker;
            AddToRoleHistory(RoleType);
            Faction = Faction.Impostors;
        }

        public DateTime LastDragged { get; set; }
        public DeadBody CurrentTarget { get; set; }
        public DeadBody CurrentlyDragging { get; set; }

        public KillButton DragDropButton
        {
            get => _dragDropButton;
            set
            {
                _dragDropButton = value;
                ExtraButtons.Clear();
                ExtraButtons.Add(value);
            }
        }

        public float DragTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastDragged;
            var num = CustomGameOptions.DragCd * 1000f;
            var flag2 = num - (float) timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float) timeSpan.TotalMilliseconds) / 1000f;
        }
    }
}