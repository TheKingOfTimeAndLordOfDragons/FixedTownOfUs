using System;
using System.Collections.Generic;
using System.Linq;
using Reactor.Utilities;
using TownOfUs.Extensions;
using UnityEngine;

namespace TownOfUs.Roles
{
    public class Plaguebearer : Role
    {
        public PlayerControl ClosestPlayer;
        public List<byte> InfectedPlayers = new List<byte>();
        public DateTime LastInfected;

        public int InfectedAlive => InfectedPlayers.Count(x => Utils.PlayerById(x) != null && Utils.PlayerById(x).Data != null && !Utils.PlayerById(x).Data.IsDead && !Utils.PlayerById(x).Data.Disconnected);
        public bool CanTransform => PlayerControl.AllPlayerControls.ToArray().Count(x => x != null && !x.Data.IsDead && !x.Data.Disconnected) <= InfectedAlive;

        public Plaguebearer(PlayerControl player) : base(player)
        {
            Name = "Plaguebearer";
            ImpostorText = () => Language.GetString("roles.plaguebearer");
            TaskText = () => Language.GetString("roles.plaguebearer");
            Color = Patches.Colors.Plaguebearer;
            RoleType = RoleEnum.Plaguebearer;
            AddToRoleHistory(RoleType);
            Faction = Faction.NeutralKilling;
            InfectedPlayers.Add(player.PlayerId);
        }

        public float InfectTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastInfected;
            var num = CustomGameOptions.InfectCd * 1000f;
            var flag2 = num - (float)timeSpan.TotalMilliseconds < 0f;
            if (flag2) return 0;
            return (num - (float)timeSpan.TotalMilliseconds) / 1000f;
        }

        public void RpcSpreadInfection(PlayerControl source, PlayerControl target)
        {
            new WaitForSeconds(1f);
            SpreadInfection(source, target);
            Utils.Rpc(CustomRPC.Infect, Player.PlayerId, source.PlayerId, target.PlayerId);
        }

        public void SpreadInfection(PlayerControl source, PlayerControl target)
        {
            if (InfectedPlayers.Contains(source.PlayerId) && !InfectedPlayers.Contains(target.PlayerId)) InfectedPlayers.Add(target.PlayerId);
            else if (InfectedPlayers.Contains(target.PlayerId) && !InfectedPlayers.Contains(source.PlayerId)) InfectedPlayers.Add(source.PlayerId);
        }

        public void TurnPestilence()
        {
            var oldRole = GetRole(Player);
            var killsList = (oldRole.CorrectAssassinKills, oldRole.IncorrectAssassinKills);
            RoleDictionary.Remove(Player.PlayerId);
            var role = new Pestilence(Player);
            role.CorrectAssassinKills = killsList.CorrectAssassinKills;
            role.IncorrectAssassinKills = killsList.IncorrectAssassinKills;
            if (Player == PlayerControl.LocalPlayer)
            {
                Coroutines.Start(Utils.FlashCoroutine(Patches.Colors.Pestilence));
                role.RegenTask();
            }
        }
    }
}