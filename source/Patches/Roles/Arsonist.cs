﻿using System;
using System.Collections.Generic;
using System.Linq;
using TownOfUs.CrewmateRoles.MedicMod;
using TownOfUs.Extensions;
using TownOfUs.Patches;

namespace TownOfUs.Roles
{
    public class Arsonist : Role
    {
        private KillButton _igniteButton;
        public PlayerControl ClosestPlayerDouse;
        public PlayerControl ClosestPlayerIgnite;
        public List<byte> DousedPlayers = new List<byte>();
        public DateTime LastDoused;
        public bool LastKiller = false;

        public int DousedAlive => DousedPlayers.Count(x => Utils.PlayerById(x) != null && Utils.PlayerById(x).Data != null && !Utils.PlayerById(x).Data.IsDead && !Utils.PlayerById(x).Data.Disconnected);


        public Arsonist(PlayerControl player) : base(player)
        {
            Name = "Arsonist";
            ImpostorText = () => Language.GetString("roles.arsonist");
            TaskText = () => Language.GetString("roles.arsonist");
            Color = Patches.Colors.Arsonist;
            LastDoused = DateTime.UtcNow;
            RoleType = RoleEnum.Arsonist;
            AddToRoleHistory(RoleType);
            Faction = Faction.NeutralKilling;
        }

        public KillButton IgniteButton
        {
            get => _igniteButton;
            set
            {
                _igniteButton = value;
                ExtraButtons.Clear();
                ExtraButtons.Add(value);
            }
        }

        public float DouseTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastDoused;
            var num = CustomGameOptions.DouseCd * 1000f;
            var flag2 = num - (float) timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float) timeSpan.TotalMilliseconds) / 1000f;
        }

        public void Ignite()
        {
            foreach (var playerId in DousedPlayers)
            {
                var player = Utils.PlayerById(playerId);
                if (!player.Is(RoleEnum.Pestilence) && !player.IsShielded() && !player.IsProtected() && player != ShowRoundOneShield.FirstRoundShielded)
                {
                    Utils.RpcMultiMurderPlayer(Player, player);
                }
                else if (player.IsShielded())
                {
                    var medic = player.GetMedic().Player.PlayerId;
                    Utils.Rpc(CustomRPC.AttemptSound, medic, player.PlayerId);
                    StopKill.BreakShield(medic, player.PlayerId, CustomGameOptions.ShieldBreaks);
                }
            }
            DousedPlayers.Clear();
        }
    }
}
