using System.Collections.Generic;
using System.Linq;
using System.Text;
using HarmonyLib;
using Reactor.Utilities.Extensions;
using TownOfUs.Extensions;
using TownOfUs.Patches.ScreenEffects;
using TownOfUs.Roles;
using TownOfUs.Roles.Modifiers;
using UnityEngine;

namespace TownOfUs.Patches
{
    enum CustomGameOverReason {
        JesterWin = 10,
        ExecutionerWin = 11,
        GlitchWin = 12,
        ArsonistWin = 13,
        PhantomWin = 14,
        JuggernautWin = 15,
        PlaguebearerWin = 16,
        PestilenceWin = 17,
        WerewolfWin = 18,
        DoomsayerWin = 19,
        VampireWin = 20,
        LoversWin = 21,
        SurvivorOnlyWin = 22,
        NobodyWins = 23,
    }

    enum WinCondition {
        Default,
        JesterWin,
        ExecutionerWin,
        GlitchWin,
        ArsonistWin,
        PhantomWin,
        JuggernautWin,
        PlaguebearerWin,
        PestilenceWin,
        WerewolfWin,
        DoomsayerWin,
        VampireWin,
        LoversTeamWin,
        LoversSoloWin,
        SurvivorOnlyWin,
        AdditionalGABonusWin,
        AdditionalAliveSurvivorBonusWin,
    }

    static class AdditionalTempData {
        public static WinCondition winCondition = WinCondition.Default;
        public static List<WinCondition> additionalWinConditions = new List<WinCondition>();

        public static List<PlayerRoleInfo> playerRoles = new List<PlayerRoleInfo>();
        public static List<Winners> otherWinners = new List<Winners>();

        public static void clear() {
            playerRoles.Clear();
            additionalWinConditions.Clear();
            otherWinners.Clear();
            winCondition = WinCondition.Default;
        }

        internal class PlayerRoleInfo {
            public string PlayerName { get; set; }
            public bool Loved { get; set; }
            public bool ExeTarget { get; set; }
            public bool GATarget { get; set; }
            public string Role { get; set; }
        }

        internal class Winners
        {
            public string PlayerName { get; set; }
            public RoleEnum Role { get; set; }
        }
    }

    [HarmonyPatch(typeof(AmongUsClient), nameof(AmongUsClient.OnGameEnd))]
    public class OnGameEndPatch {
        private static GameOverReason gameOverReason;
        public static void Prefix(AmongUsClient __instance, [HarmonyArgument(0)]ref EndGameResult endGameResult) {
            gameOverReason = endGameResult.GameOverReason;
            if ((int)endGameResult.GameOverReason >= 10) endGameResult.GameOverReason = GameOverReason.ImpostorByKill;
        }

        public static void Postfix(AmongUsClient __instance, [HarmonyArgument(0)]ref EndGameResult endGameResult) {
            if (CameraEffect.singleton) CameraEffect.singleton.materials.Clear();
            AdditionalTempData.clear();

            var playerRole = "";
            bool loved = false;
            bool exeTarget = false;
            bool gaTarget = false;
            foreach (var playerControl in PlayerControl.AllPlayerControls) {
                loved = playerControl.IsLover();
                exeTarget = playerControl.IsExeTarget();
                gaTarget = playerControl.IsGATarget();

                playerRole = "";
                foreach (var role in Role.RoleHistory.Where(x => x.Key == playerControl.PlayerId))
                {
                    if (role.Value == RoleEnum.Crewmate) { playerRole += "<color=#" + Patches.Colors.Crewmate.ToHtmlStringRGBA() + ">Crewmate</color> > "; }
                    else if (role.Value == RoleEnum.Impostor) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Impostor</color> > "; }
                    else if (role.Value == RoleEnum.Altruist) { playerRole += "<color=#" + Patches.Colors.Altruist.ToHtmlStringRGBA() + ">Altruist</color> > "; }
                    else if (role.Value == RoleEnum.Engineer) { playerRole += "<color=#" + Patches.Colors.Engineer.ToHtmlStringRGBA() + ">Engineer</color> > "; }
                    else if (role.Value == RoleEnum.Investigator) { playerRole += "<color=#" + Patches.Colors.Investigator.ToHtmlStringRGBA() + ">Investigator</color> > "; }
                    else if (role.Value == RoleEnum.Mayor) { playerRole += "<color=#" + Patches.Colors.Mayor.ToHtmlStringRGBA() + ">Mayor</color> > "; }
                    else if (role.Value == RoleEnum.Medic) { playerRole += "<color=#" + Patches.Colors.Medic.ToHtmlStringRGBA() + ">Medic</color> > "; }
                    else if (role.Value == RoleEnum.Sheriff) { playerRole += "<color=#" + Patches.Colors.Sheriff.ToHtmlStringRGBA() + ">Sheriff</color> > "; }
                    else if (role.Value == RoleEnum.Swapper) { playerRole += "<color=#" + Patches.Colors.Swapper.ToHtmlStringRGBA() + ">Swapper</color> > "; }
                    else if (role.Value == RoleEnum.Seer || role.Value == RoleEnum.CultistSeer) { playerRole += "<color=#" + Patches.Colors.Seer.ToHtmlStringRGBA() + ">Seer</color> > "; }
                    else if (role.Value == RoleEnum.Snitch || role.Value == RoleEnum.CultistSnitch) { playerRole += "<color=#" + Patches.Colors.Snitch.ToHtmlStringRGBA() + ">Snitch</color> > "; }
                    else if (role.Value == RoleEnum.Spy) { playerRole += "<color=#" + Patches.Colors.Spy.ToHtmlStringRGBA() + ">Spy</color> > "; }
                    else if (role.Value == RoleEnum.Vigilante) { playerRole += "<color=#" + Patches.Colors.Vigilante.ToHtmlStringRGBA() + ">Vigilante</color> > "; }
                    else if (role.Value == RoleEnum.Arsonist) { playerRole += "<color=#" + Patches.Colors.Arsonist.ToHtmlStringRGBA() + ">Arsonist</color> > "; }
                    else if (role.Value == RoleEnum.Executioner) { playerRole += "<color=#" + Patches.Colors.Executioner.ToHtmlStringRGBA() + ">Executioner</color> > "; }
                    else if (role.Value == RoleEnum.Glitch) { playerRole += "<color=#" + Patches.Colors.Glitch.ToHtmlStringRGBA() + ">The Glitch</color> > "; }
                    else if (role.Value == RoleEnum.Jester) { playerRole += "<color=#" + Patches.Colors.Jester.ToHtmlStringRGBA() + ">Jester</color> > "; }
                    else if (role.Value == RoleEnum.Phantom) { playerRole += "<color=#" + Patches.Colors.Phantom.ToHtmlStringRGBA() + ">Phantom</color> > "; }
                    else if (role.Value == RoleEnum.Grenadier) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Grenadier</color> > "; }
                    else if (role.Value == RoleEnum.Janitor) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Janitor</color> > "; }
                    else if (role.Value == RoleEnum.Miner) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Miner</color> > "; }
                    else if (role.Value == RoleEnum.Morphling) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Morphling</color> > "; }
                    else if (role.Value == RoleEnum.Swooper) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Swooper</color> > "; }
                    else if (role.Value == RoleEnum.Undertaker) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Undertaker</color> > "; }
                    else if (role.Value == RoleEnum.Haunter) { playerRole += "<color=#" + Patches.Colors.Haunter.ToHtmlStringRGBA() + ">Haunter</color> > "; }
                    else if (role.Value == RoleEnum.Veteran) { playerRole += "<color=#" + Patches.Colors.Veteran.ToHtmlStringRGBA() + ">Veteran</color> > "; }
                    else if (role.Value == RoleEnum.Amnesiac) { playerRole += "<color=#" + Patches.Colors.Amnesiac.ToHtmlStringRGBA() + ">Amnesiac</color> > "; }
                    else if (role.Value == RoleEnum.Juggernaut) { playerRole += "<color=#" + Patches.Colors.Juggernaut.ToHtmlStringRGBA() + ">Juggernaut</color> > "; }
                    else if (role.Value == RoleEnum.Tracker) { playerRole += "<color=#" + Patches.Colors.Tracker.ToHtmlStringRGBA() + ">Tracker</color> > "; }
                    else if (role.Value == RoleEnum.Transporter) { playerRole += "<color=#" + Patches.Colors.Transporter.ToHtmlStringRGBA() + ">Transporter</color> > "; }
                    else if (role.Value == RoleEnum.Traitor) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Traitor</color> > "; }
                    else if (role.Value == RoleEnum.Medium) { playerRole += "<color=#" + Patches.Colors.Medium.ToHtmlStringRGBA() + ">Medium</color> > "; }
                    else if (role.Value == RoleEnum.Trapper) { playerRole += "<color=#" + Patches.Colors.Trapper.ToHtmlStringRGBA() + ">Trapper</color> > "; }
                    else if (role.Value == RoleEnum.Survivor) { playerRole += "<color=#" + Patches.Colors.Survivor.ToHtmlStringRGBA() + ">Survivor</color> > "; }
                    else if (role.Value == RoleEnum.GuardianAngel) { playerRole += "<color=#" + Patches.Colors.GuardianAngel.ToHtmlStringRGBA() + ">Guardian Angel</color> > "; }
                    else if (role.Value == RoleEnum.Mystic || role.Value == RoleEnum.CultistMystic) { playerRole += "<color=#" + Patches.Colors.Mystic.ToHtmlStringRGBA() + ">Mystic</color> > "; }
                    else if (role.Value == RoleEnum.Blackmailer) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Blackmailer</color> > "; }
                    else if (role.Value == RoleEnum.Plaguebearer) { playerRole += "<color=#" + Patches.Colors.Plaguebearer.ToHtmlStringRGBA() + ">Plaguebearer</color> > "; }
                    else if (role.Value == RoleEnum.Pestilence) { playerRole += "<color=#" + Patches.Colors.Pestilence.ToHtmlStringRGBA() + ">Pestilence</color> > "; }
                    else if (role.Value == RoleEnum.Werewolf) { playerRole += "<color=#" + Patches.Colors.Werewolf.ToHtmlStringRGBA() + ">Werewolf</color> > "; }
                    else if (role.Value == RoleEnum.Detective) { playerRole += "<color=#" + Patches.Colors.Detective.ToHtmlStringRGBA() + ">Detective</color> > "; }
                    else if (role.Value == RoleEnum.Escapist) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Escapist</color> > "; }
                    else if (role.Value == RoleEnum.Necromancer) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Necromancer</color> > "; }
                    else if (role.Value == RoleEnum.Whisperer) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Whisperer</color> > "; }
                    else if (role.Value == RoleEnum.Chameleon) { playerRole += "<color=#" + Patches.Colors.Chameleon.ToHtmlStringRGBA() + ">Chameleon</color> > "; }
                    else if (role.Value == RoleEnum.Imitator) { playerRole += "<color=#" + Patches.Colors.Imitator.ToHtmlStringRGBA() + ">Imitator</color> > "; }
                    else if (role.Value == RoleEnum.Bomber) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Bomber</color> > "; }
                    else if (role.Value == RoleEnum.Doomsayer) { playerRole += "<color=#" + Patches.Colors.Doomsayer.ToHtmlStringRGBA() + ">Doomsayer</color> > "; }
                    else if (role.Value == RoleEnum.Vampire) { playerRole += "<color=#" + Patches.Colors.Vampire.ToHtmlStringRGBA() + ">Vampire</color> > "; }
                    else if (role.Value == RoleEnum.VampireHunter) { playerRole += "<color=#" + Patches.Colors.VampireHunter.ToHtmlStringRGBA() + ">Vampire Hunter</color> > "; }
                    else if (role.Value == RoleEnum.Prosecutor) { playerRole += "<color=#" + Patches.Colors.Prosecutor.ToHtmlStringRGBA() + ">Prosecutor</color> > "; }
                    else if (role.Value == RoleEnum.Warlock) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Warlock</color> > "; }
                    else if (role.Value == RoleEnum.Oracle) { playerRole += "<color=#" + Patches.Colors.Oracle.ToHtmlStringRGBA() + ">Oracle</color> > "; }
                    else if (role.Value == RoleEnum.Venerer) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Venerer</color> > "; }
                    else if (role.Value == RoleEnum.Aurial) { playerRole += "<color=#" + Patches.Colors.Aurial.ToHtmlStringRGBA() + ">Aurial</color> > "; }
                    if (CustomGameOptions.GameMode == GameMode.Cultist && playerControl.Data.IsImpostor())
                    {
                        if (role.Value == RoleEnum.Engineer) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Demolitionist</color> > "; }
                        else if (role.Value == RoleEnum.Investigator) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Consigliere</color> > "; }
                        else if (role.Value == RoleEnum.CultistMystic) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Clairvoyant</color> > "; }
                        else if (role.Value == RoleEnum.CultistSnitch) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Informant</color> > "; }
                        else if (role.Value == RoleEnum.Spy) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Rogue Agent</color> > "; }
                        else if (role.Value == RoleEnum.Vigilante) { playerRole += "<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Assassin</color> > "; }
                    }
                }
                playerRole = playerRole.Remove(playerRole.Length - 3);

                if (playerControl.Is(ModifierEnum.Giant))
                {
                    playerRole += " (<color=#" + Patches.Colors.Giant.ToHtmlStringRGBA() + ">Giant</color>)";
                }
                else if (playerControl.Is(ModifierEnum.ButtonBarry))
                {
                    playerRole += " (<color=#" + Patches.Colors.ButtonBarry.ToHtmlStringRGBA() + ">Button Barry</color>)";
                }
                else if (playerControl.Is(ModifierEnum.Aftermath))
                {
                    playerRole += " (<color=#" + Patches.Colors.Aftermath.ToHtmlStringRGBA() + ">Aftermath</color>)";
                }
                else if (playerControl.Is(ModifierEnum.Bait))
                {
                    playerRole += " (<color=#" + Patches.Colors.Bait.ToHtmlStringRGBA() + ">Bait</color>)";
                }
                else if (playerControl.Is(ModifierEnum.Diseased))
                {
                    playerRole += " (<color=#" + Patches.Colors.Diseased.ToHtmlStringRGBA() + ">Diseased</color>)";
                }
                else if (playerControl.Is(ModifierEnum.Flash))
                {
                    playerRole += " (<color=#" + Patches.Colors.Flash.ToHtmlStringRGBA() + ">Flash</color>)";
                }
                else if (playerControl.Is(ModifierEnum.Tiebreaker))
                {
                    playerRole += " (<color=#" + Patches.Colors.Tiebreaker.ToHtmlStringRGBA() + ">Tiebreaker</color>)";
                }
                else if (playerControl.Is(ModifierEnum.Torch))
                {
                    playerRole += " (<color=#" + Patches.Colors.Torch.ToHtmlStringRGBA() + ">Torch</color>)";
                }
                else if (playerControl.Is(ModifierEnum.Lover))
                {
                    playerRole += " (<color=#" + Patches.Colors.Lovers.ToHtmlStringRGBA() + ">Lover</color>)";
                }
                else if (playerControl.Is(ModifierEnum.Sleuth))
                {
                    playerRole += " (<color=#" + Patches.Colors.Sleuth.ToHtmlStringRGBA() + ">Sleuth</color>)";
                }
                else if (playerControl.Is(ModifierEnum.Radar))
                {
                    playerRole += " (<color=#" + Patches.Colors.Radar.ToHtmlStringRGBA() + ">Radar</color>)";
                }
                else if (playerControl.Is(ModifierEnum.Disperser))
                {
                    playerRole += " (<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Disperser</color>)";
                }
                else if (playerControl.Is(ModifierEnum.Multitasker))
                {
                    playerRole += " (<color=#" + Patches.Colors.Multitasker.ToHtmlStringRGBA() + ">Multitasker</color>)";
                }
                else if (playerControl.Is(ModifierEnum.DoubleShot))
                {
                    playerRole += " (<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Double Shot</color>)";
                }
                else if (playerControl.Is(ModifierEnum.Underdog))
                {
                    playerRole += " (<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + ">Underdog</color>)";
                }
                else if (playerControl.Is(ModifierEnum.Frosty))
                {
                    playerRole += " (<color=#" + Patches.Colors.Frosty.ToHtmlStringRGBA() + ">Frosty</color>)";
                }
                var player = Role.GetRole(playerControl);
                if (playerControl.Is(RoleEnum.Phantom) || playerControl.Is(Faction.Crewmates))
                {
                    if ((player.TotalTasks - player.TasksLeft)/player.TotalTasks == 1) playerRole += " | Tasks: <color=#" + Color.green.ToHtmlStringRGBA() + $">{player.TotalTasks - player.TasksLeft}/{player.TotalTasks}</color>";
                    else playerRole += $" | Tasks: {player.TotalTasks - player.TasksLeft}/{player.TotalTasks}";
                }
                if (player.Kills > 0 && !playerControl.Is(Faction.Crewmates))
                {
                    playerRole += " |<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + $"> Kills: {player.Kills}</color>";
                }
                if (player.CorrectKills > 0)
                {
                    playerRole += " |<color=#" + Color.green.ToHtmlStringRGBA() + $"> Correct Kills: {player.CorrectKills}</color>";
                }
                if (player.IncorrectKills > 0)
                {
                    playerRole += " |<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + $"> Incorrect Kills: {player.IncorrectKills}</color>";
                }
                if (player.CorrectAssassinKills > 0)
                {
                    playerRole += " |<color=#" + Color.green.ToHtmlStringRGBA() + $"> Correct Guesses: {player.CorrectAssassinKills}</color>";
                }
                if (player.IncorrectAssassinKills > 0)
                {
                    playerRole += " |<color=#" + Patches.Colors.Impostor.ToHtmlStringRGBA() + $"> Incorrect Guesses: {player.IncorrectAssassinKills}</color>";
                }

                AdditionalTempData.playerRoles.Add(new AdditionalTempData.PlayerRoleInfo()
                {
                    PlayerName = playerControl.Data.PlayerName,
                    Loved = loved,
                    ExeTarget = exeTarget,
                    GATarget = gaTarget,
                    Role = playerRole
                });
            }

            if (!CustomGameOptions.NeutralEvilWinEndsGame) {
                foreach (var doomsayer in Role.GetRoles(RoleEnum.Doomsayer))
                {
                    var doom = (Doomsayer)doomsayer;
                    if (Doomsayer.WonByGuessing) AdditionalTempData.otherWinners.Add(new AdditionalTempData.Winners() { PlayerName = doom.Player.Data.PlayerName, Role = RoleEnum.Doomsayer });
                }
                foreach (var executioner in Role.GetRoles(RoleEnum.Executioner))
                {
                    var exe = (Executioner)executioner;
                    if (Executioner.TargetVotedOut) AdditionalTempData.otherWinners.Add(new AdditionalTempData.Winners() { PlayerName = exe.Player.Data.PlayerName, Role = RoleEnum.Executioner });
                }
                foreach (var jester in Role.GetRoles(RoleEnum.Jester))
                {
                    var jest = (Jester)jester;
                    if (Jester.VotedOut) AdditionalTempData.otherWinners.Add(new AdditionalTempData.Winners() { PlayerName = jest.Player.Data.PlayerName, Role = RoleEnum.Jester });
                }
                foreach (var phantom in Role.GetRoles(RoleEnum.Phantom))
                {
                    var phan = (Phantom)phantom;
                    if (Phantom.CompletedTasks) AdditionalTempData.otherWinners.Add(new AdditionalTempData.Winners() { PlayerName = phan.Player.Data.PlayerName, Role = RoleEnum.Phantom });
                }
            }

            // Remove Neutrals from winners (if they win, they'll be readded)
            List<PlayerControl> notWinners = new List<PlayerControl>();
            foreach (var role in Role.GetRoles(RoleEnum.Amnesiac))
            {
                var amne = (Amnesiac)role;
                notWinners.Add(amne.Player);
            }
            foreach (var role in Role.GetRoles(RoleEnum.GuardianAngel))
            {
                var ga = (GuardianAngel)role;
                notWinners.Add(ga.Player);
            }
            foreach (var role in Role.GetRoles(RoleEnum.Survivor))
            {
                var surv = (Survivor)role;
                notWinners.Add(surv.Player);
            }
            foreach (var role in Role.GetRoles(RoleEnum.Doomsayer))
            {
                var doom = (Doomsayer)role;
                notWinners.Add(doom.Player);
            }
            foreach (var role in Role.GetRoles(RoleEnum.Executioner))
            {
                var exe = (Executioner)role;
                notWinners.Add(exe.Player);
            }
            foreach (var role in Role.GetRoles(RoleEnum.Jester))
            {
                var jest = (Jester)role;
                notWinners.Add(jest.Player);
            }
            foreach (var role in Role.GetRoles(RoleEnum.Phantom))
            {
                var phan = (Phantom)role;
                notWinners.Add(phan.Player);
            }
            foreach (var role in Role.GetRoles(RoleEnum.Arsonist))
            {
                var arso = (Arsonist)role;
                notWinners.Add(arso.Player);
            }
            foreach (var role in Role.GetRoles(RoleEnum.Juggernaut))
            {
                var jugg = (Juggernaut)role;
                notWinners.Add(jugg.Player);
            }
            foreach (var role in Role.GetRoles(RoleEnum.Pestilence))
            {
                var pest = (Pestilence)role;
                notWinners.Add(pest.Player);
            }
            foreach (var role in Role.GetRoles(RoleEnum.Plaguebearer))
            {
                var pb = (Plaguebearer)role;
                notWinners.Add(pb.Player);
            }
            foreach (var role in Role.GetRoles(RoleEnum.Glitch))
            {
                var glitch = (Glitch)role;
                notWinners.Add(glitch.Player);
            }
            foreach (var role in Role.GetRoles(RoleEnum.Vampire))
            {
                var vamp = (Vampire)role;
                notWinners.Add(vamp.Player);
            }
            foreach (var role in Role.GetRoles(RoleEnum.Werewolf))
            {
                var ww = (Werewolf)role;
                notWinners.Add(ww.Player);
            }

            List<WinningPlayerData> winnersToRemove = new List<WinningPlayerData>();
            foreach (WinningPlayerData winner in TempData.winners.GetFastEnumerator()) {
                if (notWinners.Any(x => x.Data.PlayerName == winner.PlayerName)) winnersToRemove.Add(winner);
            }
            foreach (var winner in winnersToRemove) TempData.winners.Remove(winner);

            bool nobodyWins = gameOverReason == (GameOverReason)CustomGameOverReason.NobodyWins;
            
            bool survivorOnlyWin = false;
            foreach (var role in Role.GetRoles(RoleEnum.Survivor))
            {
                var surv = (Survivor)role;
                survivorOnlyWin = surv.Player != null && gameOverReason == (GameOverReason)CustomGameOverReason.SurvivorOnlyWin;
            }
            bool loversWin = Lover.existingAndAlive() && (gameOverReason == (GameOverReason)CustomGameOverReason.LoversWin || (GameManager.Instance.DidHumansWin(gameOverReason) && !Lover.existingWithKiller()));
            bool jesterWin = false;
            foreach (var role in Role.GetRoles(RoleEnum.Jester)) {
                var jester = (Jester)role;
                jesterWin = jester.Player != null && gameOverReason == (GameOverReason)CustomGameOverReason.JesterWin;
            }
            bool executionerWin = false;
            foreach (var role in Role.GetRoles(RoleEnum.Executioner)) {
                var executioner = (Executioner)role;
                executionerWin = executioner.Player != null && gameOverReason == (GameOverReason)CustomGameOverReason.ExecutionerWin;
            }
            bool phantomWin = false;
            foreach (var role in Role.GetRoles(RoleEnum.Phantom)) {
                var phantom = (Phantom)role;
                phantomWin = phantom.Player != null && gameOverReason == (GameOverReason)CustomGameOverReason.PhantomWin;
            }
            bool doomsayerWin = false;
            foreach (var role in Role.GetRoles(RoleEnum.Doomsayer)) {
                var doomsayer = (Doomsayer)role;
                doomsayerWin = doomsayer.Player != null && gameOverReason == (GameOverReason)CustomGameOverReason.DoomsayerWin;
            }

            bool glitchWin = false;
            foreach (var role in Role.GetRoles(RoleEnum.Glitch)) {
                var glitch = (Glitch)role;
                glitchWin = glitch.Player != null && gameOverReason == (GameOverReason)CustomGameOverReason.GlitchWin;
            }
            bool arsonistWin = false;
            foreach (var role in Role.GetRoles(RoleEnum.Arsonist)) {
                var arsonist = (Arsonist)role;
                arsonistWin = arsonist.Player != null && gameOverReason == (GameOverReason)CustomGameOverReason.ArsonistWin;
            }
            bool juggernautWin = false;
            foreach (var role in Role.GetRoles(RoleEnum.Juggernaut)) {
                var juggernaut = (Juggernaut)role;
                juggernautWin = juggernaut.Player != null && gameOverReason == (GameOverReason)CustomGameOverReason.JuggernautWin;
            }
            bool plaguebearerWin = false;
            foreach (var role in Role.GetRoles(RoleEnum.Plaguebearer)) {
                var plaguebearer = (Plaguebearer)role;
                plaguebearerWin = plaguebearer.Player != null && gameOverReason == (GameOverReason)CustomGameOverReason.PlaguebearerWin;
            }
            bool pestilenceWin = false;
            foreach (var role in Role.GetRoles(RoleEnum.Pestilence)) {
                var pestilence = (Pestilence)role;
                pestilenceWin = pestilence.Player != null && gameOverReason == (GameOverReason)CustomGameOverReason.PestilenceWin;
            }
            bool werewolfWin = false;
            foreach (var role in Role.GetRoles(RoleEnum.Werewolf)) {
                var werewolf = (Werewolf)role;
                werewolfWin = werewolf.Player != null && gameOverReason == (GameOverReason)CustomGameOverReason.WerewolfWin;
            }
            bool vampireWin = false;
            foreach (var role in Role.GetRoles(RoleEnum.Vampire)) {
                var vampire = (Vampire)role;
                vampireWin = vampire.Player != null && gameOverReason == (GameOverReason)CustomGameOverReason.VampireWin;
            }

            if (nobodyWins) {
                TempData.winners = new Il2CppSystem.Collections.Generic.List<WinningPlayerData>();
            }
            else if (survivorOnlyWin) {
                AdditionalTempData.winCondition = WinCondition.SurvivorOnlyWin;
                TempData.winners = new Il2CppSystem.Collections.Generic.List<WinningPlayerData>();
                foreach (var role in Role.GetRoles(RoleEnum.Survivor))
                {
                    var surv = (Survivor)role;
                    WinningPlayerData wpd = new WinningPlayerData(surv.Player.Data);
                    TempData.winners.Add(wpd);
                }
            }
            else if (loversWin) {
                if (!Lover.existingWithKiller()) {
                    AdditionalTempData.winCondition = WinCondition.LoversTeamWin;
                    TempData.winners = new Il2CppSystem.Collections.Generic.List<WinningPlayerData>();
                    foreach (var modifier in Modifier.GetModifiers(ModifierEnum.Lover))
                    {
                        var lover = (Lover)modifier;
                        foreach (PlayerControl p in PlayerControl.AllPlayerControls) {
                            if (p == null) continue;
                            if (p == lover.Player || p == lover.OtherLover.Player)
                                TempData.winners.Add(new WinningPlayerData(p.Data));
                            else if (p.Is(Faction.Crewmates))
                                TempData.winners.Add(new WinningPlayerData(p.Data));
                        }
                    }
                }
                else {
                    AdditionalTempData.winCondition = WinCondition.LoversSoloWin;
                    foreach (var modifier in Modifier.GetModifiers(ModifierEnum.Lover))
                    {
                        var lover = (Lover)modifier;
                        TempData.winners = new Il2CppSystem.Collections.Generic.List<WinningPlayerData>();
                        TempData.winners.Add(new WinningPlayerData(lover.Player.Data));
                        TempData.winners.Add(new WinningPlayerData(lover.OtherLover.Player.Data));
                    }
                }
            }
            else if (jesterWin) {
                AdditionalTempData.winCondition = WinCondition.JesterWin;
                foreach (var role in Role.GetRoles(RoleEnum.Jester))
                {
                    TempData.winners = new Il2CppSystem.Collections.Generic.List<WinningPlayerData>();
                    var jest = (Jester)role;
                    WinningPlayerData wpd = new WinningPlayerData(jest.Player.Data);
                    TempData.winners.Add(wpd);
                }
            }
            else if (executionerWin) {
                AdditionalTempData.winCondition = WinCondition.ExecutionerWin;
                foreach (var role in Role.GetRoles(RoleEnum.Executioner))
                {
                    TempData.winners = new Il2CppSystem.Collections.Generic.List<WinningPlayerData>();
                    var exe = (Executioner)role;
                    WinningPlayerData wpd = new WinningPlayerData(exe.Player.Data);
                    TempData.winners.Add(wpd);
                }
            }
            else if (phantomWin) {
                AdditionalTempData.winCondition = WinCondition.PhantomWin;
                foreach (var role in Role.GetRoles(RoleEnum.Phantom))
                {
                    TempData.winners = new Il2CppSystem.Collections.Generic.List<WinningPlayerData>();
                    var phantom = (Phantom)role;
                    WinningPlayerData wpd = new WinningPlayerData(phantom.Player.Data);
                    TempData.winners.Add(wpd);
                }
            }
            else if (doomsayerWin) {
                AdditionalTempData.winCondition = WinCondition.DoomsayerWin;
                foreach (var role in Role.GetRoles(RoleEnum.Doomsayer))
                {
                    TempData.winners = new Il2CppSystem.Collections.Generic.List<WinningPlayerData>();
                    var doom = (Doomsayer)role;
                    WinningPlayerData wpd = new WinningPlayerData(doom.Player.Data);
                    TempData.winners.Add(wpd);
                }
            }
            else if (glitchWin) {
                AdditionalTempData.winCondition = WinCondition.GlitchWin;
                foreach (var role in Role.GetRoles(RoleEnum.Glitch))
                {
                    TempData.winners = new Il2CppSystem.Collections.Generic.List<WinningPlayerData>();
                    var glitch = (Glitch)role;
                    WinningPlayerData wpd = new WinningPlayerData(glitch.Player.Data);
                    wpd.IsImpostor = false;
                    TempData.winners.Add(wpd);
                }
            }
            else if (arsonistWin) {
                AdditionalTempData.winCondition = WinCondition.ArsonistWin;
                foreach (var role in Role.GetRoles(RoleEnum.Arsonist))
                {
                    TempData.winners = new Il2CppSystem.Collections.Generic.List<WinningPlayerData>();
                    var arso = (Arsonist)role;
                    WinningPlayerData wpd = new WinningPlayerData(arso.Player.Data);
                    wpd.IsImpostor = false;
                    TempData.winners.Add(wpd);
                }
            }
            else if (juggernautWin) {
                AdditionalTempData.winCondition = WinCondition.JuggernautWin;
                foreach (var role in Role.GetRoles(RoleEnum.Juggernaut))
                {
                    TempData.winners = new Il2CppSystem.Collections.Generic.List<WinningPlayerData>();
                    var jugg = (Juggernaut)role;
                    WinningPlayerData wpd = new WinningPlayerData(jugg.Player.Data);
                    wpd.IsImpostor = false;
                    TempData.winners.Add(wpd);
                }
            }
            else if (plaguebearerWin) {
                AdditionalTempData.winCondition = WinCondition.PlaguebearerWin;
                foreach (var role in Role.GetRoles(RoleEnum.Plaguebearer))
                {
                    TempData.winners = new Il2CppSystem.Collections.Generic.List<WinningPlayerData>();
                    var plag = (Plaguebearer)role;
                    WinningPlayerData wpd = new WinningPlayerData(plag.Player.Data);
                    wpd.IsImpostor = false;
                    TempData.winners.Add(wpd);
                }
            }
            else if (pestilenceWin) {
                AdditionalTempData.winCondition = WinCondition.PestilenceWin;
                foreach (var role in Role.GetRoles(RoleEnum.Pestilence))
                {
                    TempData.winners = new Il2CppSystem.Collections.Generic.List<WinningPlayerData>();
                    var pest = (Pestilence)role;
                    WinningPlayerData wpd = new WinningPlayerData(pest.Player.Data);
                    wpd.IsImpostor = false;
                    TempData.winners.Add(wpd);
                }
            }
            else if (werewolfWin) {
                AdditionalTempData.winCondition = WinCondition.WerewolfWin;
                foreach (var role in Role.GetRoles(RoleEnum.Werewolf))
                {
                    TempData.winners = new Il2CppSystem.Collections.Generic.List<WinningPlayerData>();
                    var were = (Werewolf)role;
                    WinningPlayerData wpd = new WinningPlayerData(were.Player.Data);
                    wpd.IsImpostor = false;
                    TempData.winners.Add(wpd);
                }
            }
            else if (vampireWin) {
                AdditionalTempData.winCondition = WinCondition.VampireWin;
                foreach (var role in Role.GetRoles(RoleEnum.Vampire))
                {
                    TempData.winners = new Il2CppSystem.Collections.Generic.List<WinningPlayerData>();
                    var vamp = (Vampire)role;
                    WinningPlayerData wpd = new WinningPlayerData(vamp.Player.Data);
                    wpd.IsImpostor = false;
                    TempData.winners.Add(wpd);
                }
            }

            foreach (var role in Role.GetRoles(RoleEnum.Survivor))
            {
                var surv = (Survivor)role;
                if (surv.Player != null && !surv.Player.Data.IsDead && AdditionalTempData.winCondition != WinCondition.SurvivorOnlyWin) {
                    if (!TempData.winners.ToArray().Any(x => x.PlayerName == surv.Player.Data.PlayerName))
                        TempData.winners.Add(new WinningPlayerData(surv.Player.Data));
                    AdditionalTempData.additionalWinConditions.Add(WinCondition.AdditionalAliveSurvivorBonusWin); // The Survivor wins if alive
                }
            }

            foreach (var role in Role.GetRoles(RoleEnum.GuardianAngel))
            {
                var ga = (GuardianAngel)role;
                if (ga.target != null && ga.Player != null) {
                    WinningPlayerData winningClient = null;
                    foreach (WinningPlayerData winner in TempData.winners.GetFastEnumerator()) {
                        if (winner.PlayerName == ga.target.Data.PlayerName)
                            winningClient = winner;
                    }
                    if (winningClient != null) { // The Guardian Angel wins if the client is winning
                        if (!TempData.winners.ToArray().Any(x => x.PlayerName == ga.Player.Data.PlayerName))
                            TempData.winners.Add(new WinningPlayerData(ga.Player.Data));
                        AdditionalTempData.additionalWinConditions.Add(WinCondition.AdditionalGABonusWin); // The Guardian Angel wins together with the client
                    }
                }
            }
        }
    }

    [HarmonyPatch(typeof(EndGameManager), nameof(EndGameManager.SetEverythingUp))]
    public class EndGameManagerSetUpPatch {
        public static void Postfix(EndGameManager __instance) {
            // Delete and readd PoolablePlayers always showing the name and role of the player
            foreach (PoolablePlayer pb in __instance.transform.GetComponentsInChildren<PoolablePlayer>()) {
                UnityEngine.Object.Destroy(pb.gameObject);
            }
            int num = Mathf.CeilToInt(7.5f);
            List<WinningPlayerData> list = TempData.winners.ToArray().ToList().OrderBy(delegate(WinningPlayerData b)
            {
                if (!b.IsYou)
                {
                    return 0;
                }
                return -1;
            }).ToList<WinningPlayerData>();
            for (int i = 0; i < list.Count; i++) {
                WinningPlayerData winningPlayerData2 = list[i];
                int num2 = (i % 2 == 0) ? -1 : 1;
                int num3 = (i + 1) / 2;
                float num4 = (float)num3 / (float)num;
                float num5 = Mathf.Lerp(1f, 0.75f, num4);
                float num6 = (float)((i == 0) ? -8 : -1);
                PoolablePlayer poolablePlayer = UnityEngine.Object.Instantiate<PoolablePlayer>(__instance.PlayerPrefab, __instance.transform);
                poolablePlayer.transform.localPosition = new Vector3(1f * (float)num2 * (float)num3 * num5, FloatRange.SpreadToEdges(-1.125f, 0f, num3, num), num6 + (float)num3 * 0.01f) * 0.9f;
                float num7 = Mathf.Lerp(1f, 0.65f, num4) * 0.9f;
                Vector3 vector = new Vector3(num7, num7, 1f);
                poolablePlayer.transform.localScale = vector;
                if (winningPlayerData2.IsDead) {
                    poolablePlayer.SetBodyAsGhost();
                    poolablePlayer.SetDeadFlipX(i % 2 == 0);
                } else {
                    poolablePlayer.SetFlipX(i % 2 == 0);
                }
                poolablePlayer.UpdateFromPlayerOutfit(winningPlayerData2, PlayerMaterial.MaskType.None, winningPlayerData2.IsDead, true);

                poolablePlayer.cosmetics.nameText.color = Color.white;
                poolablePlayer.cosmetics.nameText.transform.localScale = new Vector3(1f / vector.x, 1f / vector.y, 1f / vector.z);
                poolablePlayer.cosmetics.nameText.transform.localPosition = new Vector3(poolablePlayer.cosmetics.nameText.transform.localPosition.x, poolablePlayer.cosmetics.nameText.transform.localPosition.y, -15f);
                poolablePlayer.cosmetics.nameText.text = winningPlayerData2.PlayerName;

                foreach(var data in AdditionalTempData.playerRoles) {
                    if (data.PlayerName != winningPlayerData2.PlayerName) continue;
                }
            }

            // Additional code
            GameObject bonusText = UnityEngine.Object.Instantiate(__instance.WinText.gameObject);
            bonusText.transform.position = new Vector3(__instance.WinText.transform.position.x, __instance.WinText.transform.position.y - 0.5f, __instance.WinText.transform.position.z);
            bonusText.transform.localScale = new Vector3(0.7f, 0.7f, 1f);
            TMPro.TMP_Text textRenderer = bonusText.GetComponent<TMPro.TMP_Text>();
            textRenderer.text = "";

            if (AdditionalTempData.winCondition == WinCondition.JesterWin) {
                textRenderer.text = "Jester Wins";
                textRenderer.color = Colors.Jester;
                __instance.BackgroundBar.material.SetColor("_Color", Colors.Jester);
            }
            if (AdditionalTempData.winCondition == WinCondition.ExecutionerWin) {
                textRenderer.text = "Executioner Wins";
                textRenderer.color = Colors.Executioner;
                __instance.BackgroundBar.material.SetColor("_Color", Colors.Executioner);
            }
            if (AdditionalTempData.winCondition == WinCondition.GlitchWin) {
                textRenderer.text = "Glitch Wins";
                textRenderer.color = Colors.Glitch;
                __instance.BackgroundBar.material.SetColor("_Color", Colors.Glitch);
            }
            if (AdditionalTempData.winCondition == WinCondition.ArsonistWin) {
                textRenderer.text = "Arsonist Wins";
                textRenderer.color = Colors.Arsonist;
                __instance.BackgroundBar.material.SetColor("_Color", Colors.Arsonist);
            }
            if (AdditionalTempData.winCondition == WinCondition.PhantomWin) {
                textRenderer.text = "Phantom Wins";
                textRenderer.color = Colors.Phantom;
                __instance.BackgroundBar.material.SetColor("_Color", Colors.Phantom);
            }
            if (AdditionalTempData.winCondition == WinCondition.JuggernautWin) {
                textRenderer.text = "Juggernaut Wins";
                textRenderer.color = Colors.Juggernaut;
                __instance.BackgroundBar.material.SetColor("_Color", Colors.Juggernaut);
            }
            if (AdditionalTempData.winCondition == WinCondition.PlaguebearerWin) {
                textRenderer.text = "Plaguebearer Wins";
                textRenderer.color = Colors.Plaguebearer;
                __instance.BackgroundBar.material.SetColor("_Color", Colors.Plaguebearer);
            }
            if (AdditionalTempData.winCondition == WinCondition.PestilenceWin) {
                textRenderer.text = "Pestilence Wins";
                textRenderer.color = Colors.Pestilence;
                __instance.BackgroundBar.material.SetColor("_Color", Colors.Pestilence);
            }
            if (AdditionalTempData.winCondition == WinCondition.WerewolfWin) {
                textRenderer.text = "Werewolf Wins";
                textRenderer.color = Colors.Werewolf;
                __instance.BackgroundBar.material.SetColor("_Color", Colors.Werewolf);
            }
            if (AdditionalTempData.winCondition == WinCondition.DoomsayerWin) {
                textRenderer.text = "Doomsayer Wins";
                textRenderer.color = Colors.Doomsayer;
                __instance.BackgroundBar.material.SetColor("_Color", Colors.Doomsayer);
            }
            if (AdditionalTempData.winCondition == WinCondition.VampireWin) {
                textRenderer.text = "Vampire Wins";
                textRenderer.color = Colors.Vampire;
                __instance.BackgroundBar.material.SetColor("_Color", Colors.Vampire);
            }
            if (AdditionalTempData.winCondition == WinCondition.LoversTeamWin) {
                textRenderer.text = "Lovers And Crewmates Win";
                textRenderer.color = Colors.Lovers;
                __instance.BackgroundBar.material.SetColor("_Color", Colors.Lovers);
            }
            if (AdditionalTempData.winCondition == WinCondition.LoversSoloWin) {
                textRenderer.text = "Lovers Win";
                textRenderer.color = Colors.Lovers;
                __instance.BackgroundBar.material.SetColor("_Color", Colors.Lovers);
            }
            if (AdditionalTempData.winCondition == WinCondition.SurvivorOnlyWin) {
                textRenderer.text = "Survivor Only Wins";
                textRenderer.color = Colors.Survivor;
                __instance.BackgroundBar.material.SetColor("_Color", Colors.Survivor);
            }

            foreach (WinCondition cond in AdditionalTempData.additionalWinConditions) {
                if (cond == WinCondition.AdditionalGABonusWin)
                    textRenderer.text += $"\n{Utils.cs(Colors.GuardianAngel, "The Guardian Angel wins with the client")}";
                if (cond == WinCondition.AdditionalAliveSurvivorBonusWin)
                    textRenderer.text += $"\n{Utils.cs(Colors.Survivor, "The Survivors alive")}";
            }

            var position = Camera.main.ViewportToWorldPoint(new Vector3(0f, 1f, Camera.main.nearClipPlane));
            GameObject roleSummary = UnityEngine.Object.Instantiate(__instance.WinText.gameObject);
            roleSummary.transform.position = new Vector3(__instance.Navigation.ExitButton.transform.position.x + 0.1f, position.y - 0.1f, -214f); 
            roleSummary.transform.localScale = new Vector3(1f, 1f, 1f);

            var roleSummaryText = new StringBuilder();
            roleSummaryText.AppendLine("Players and roles at the end of the game:");
            foreach(var data in AdditionalTempData.playerRoles) {
                var role = string.Join(" ", data.Role);
                string loved = data.Loved ? " <color=#FF66CCFF>♥</color>" : "";
                string exeTarget = data.ExeTarget ? " <color=#8C4005FF>X</color>" : "";
                string gaTarget = data.GATarget ? " <color=#B3FFFFFF>★</color>" : "";
                roleSummaryText.AppendLine($"{data.PlayerName}{loved}{exeTarget}{gaTarget} - {role}");
            }

            if (AdditionalTempData.otherWinners.Count != 0) {
                roleSummaryText.AppendLine("\n\n\nOther Winners:");
                foreach (var data in AdditionalTempData.otherWinners)
                {
                    if (data.Role == RoleEnum.Doomsayer) roleSummaryText.AppendLine("<color=#" + Patches.Colors.Doomsayer.ToHtmlStringRGBA() + $">{data.PlayerName}</color>");
                    else if (data.Role == RoleEnum.Executioner) roleSummaryText.AppendLine("<color=#" + Patches.Colors.Executioner.ToHtmlStringRGBA() + $">{data.PlayerName}</color>");
                    else if (data.Role == RoleEnum.Jester) roleSummaryText.AppendLine("<color=#" + Patches.Colors.Jester.ToHtmlStringRGBA() + $">{data.PlayerName}</color>");
                    else if (data.Role == RoleEnum.Phantom) roleSummaryText.AppendLine("<color=#" + Patches.Colors.Phantom.ToHtmlStringRGBA() + $">{data.PlayerName}</color>");
                }
            }

            TMPro.TMP_Text roleSummaryTextMesh = roleSummary.GetComponent<TMPro.TMP_Text>();
            roleSummaryTextMesh.alignment = TMPro.TextAlignmentOptions.TopLeft;
            roleSummaryTextMesh.color = Color.white;
            roleSummaryTextMesh.fontSizeMin = 1.5f;
            roleSummaryTextMesh.fontSizeMax = 1.5f;
            roleSummaryTextMesh.fontSize = 1.5f;
                
            var roleSummaryTextMeshRectTransform = roleSummaryTextMesh.GetComponent<RectTransform>();
            roleSummaryTextMeshRectTransform.anchoredPosition = new Vector2(position.x + 3.5f, position.y - 0.1f);
            roleSummaryTextMesh.text = roleSummaryText.ToString();

            AdditionalTempData.clear();
        }
    }

    [HarmonyPatch(typeof(LogicGameFlowNormal), nameof(LogicGameFlowNormal.CheckEndCriteria))] 
    class CheckEndCriteriaPatch {
        public static bool Prefix(ShipStatus __instance) {
            if (!GameData.Instance) return false;
            if (DestroyableSingleton<TutorialManager>.InstanceExists) // InstanceExists | Don't check Custom Criteria when in Tutorial
                return true;
            var statistics = new PlayerStatistics(__instance);
            if (CheckAndEndGameForSabotageWin(__instance)) return false;
            if (CheckAndEndGameForTaskWin(__instance)) return false;
            if (CheckAndEndGameForImpostorWin(__instance, statistics)) return false;
            if (CheckAndEndGameForCrewmateWin(__instance, statistics)) return false;
            if (CheckAndEndGameForJesterWin(__instance)) return false;
            if (CheckAndEndGameForExecutionerWin(__instance)) return false;
            if (CheckAndEndGameForPhantomWin(__instance)) return false;
            if (CheckAndEndGameForDoomsayerWin(__instance)) return false;
            if (CheckAndEndGameForGlitchWin(__instance, statistics)) return false;
            if (CheckAndEndGameForArsonistWin(__instance, statistics)) return false;
            if (CheckAndEndGameForJuggernautWin(__instance, statistics)) return false;
            if (CheckAndEndGameForPlaguebearerWin(__instance, statistics)) return false;
            if (CheckAndEndGameForPestilenceWin(__instance, statistics)) return false;
            if (CheckAndEndGameForWerewolfWin(__instance, statistics)) return false;
            if (CheckAndEndGameForVampireWin(__instance, statistics)) return false;
            if (CheckAndEndGameForLoversWin(__instance, statistics)) return false;
            if (CheckAndEndGameForSurvivorOnlyWin(__instance, statistics)) return false;
            return false;
        }

        private static bool CheckAndEndGameForSabotageWin(ShipStatus __instance) {
            if (MapUtilities.Systems == null) return false;
            var systemType = MapUtilities.Systems.ContainsKey(SystemTypes.LifeSupp) ? MapUtilities.Systems[SystemTypes.LifeSupp] : null;
            if (systemType != null) {
                LifeSuppSystemType lifeSuppSystemType = systemType.TryCast<LifeSuppSystemType>();
                if (lifeSuppSystemType != null && lifeSuppSystemType.Countdown < 0f) {
                    EndGameForSabotage(__instance);
                    lifeSuppSystemType.Countdown = 10000f;
                    return true;
                }
            }
            var systemType2 = MapUtilities.Systems.ContainsKey(SystemTypes.Reactor) ? MapUtilities.Systems[SystemTypes.Reactor] : null;
            if (systemType2 == null) {
                systemType2 = MapUtilities.Systems.ContainsKey(SystemTypes.Laboratory) ? MapUtilities.Systems[SystemTypes.Laboratory] : null;
            }
            if (systemType2 != null) {
                ICriticalSabotage criticalSystem = systemType2.TryCast<ICriticalSabotage>();
                if (criticalSystem != null && criticalSystem.Countdown < 0f) {
                    EndGameForSabotage(__instance);
                    criticalSystem.ClearSabotage();
                    return true;
                }
            }
            return false;
        }

        private static bool CheckAndEndGameForTaskWin(ShipStatus __instance) {
            if (GameData.Instance.TotalTasks > 0 && GameData.Instance.TotalTasks <= GameData.Instance.CompletedTasks) {
                GameManager.Instance.RpcEndGame(GameOverReason.HumansByTask, false);
                return true;
            }
            return false;
        }

        private static bool CheckAndEndGameForImpostorWin(ShipStatus __instance, PlayerStatistics statistics) {
            if (statistics.TotalAlive - statistics.TeamImpostorsAlive <= statistics.TeamImpostorsAlive && statistics.TeamGlitchAlive == 0 && statistics.TeamArsonistAlive == 0 && statistics.TeamJuggernautAlive == 0 && statistics.TeamPlaguebearerAlive == 0 && statistics.TeamPestilenceAlive == 0 && statistics.TeamWerewolfAlive == 0 && statistics.TeamVampireAlive == 0 && statistics.TeamPowerCrewAlive == 0 && !(statistics.TeamImpostorsHasAliveLover && statistics.TeamLoversAlive == 2)) {
                GameOverReason endReason;
                switch (TempData.LastDeathReason) {
                    case DeathReason.Exile:
                        endReason = GameOverReason.ImpostorByVote;
                        break;
                    case DeathReason.Kill:
                        endReason = GameOverReason.ImpostorByKill;
                        break;
                    default:
                        endReason = GameOverReason.ImpostorByVote;
                        break;
                }
                GameManager.Instance.RpcEndGame(endReason, false);
                return true;
            }
            return false;
        }

        private static bool CheckAndEndGameForCrewmateWin(ShipStatus __instance, PlayerStatistics statistics) {
            if (statistics.TeamImpostorsAlive == 0 && statistics.TeamGlitchAlive == 0 && statistics.TeamArsonistAlive == 0 && statistics.TeamJuggernautAlive == 0 && statistics.TeamPlaguebearerAlive == 0 && statistics.TeamPestilenceAlive == 0 && statistics.TeamWerewolfAlive == 0 && statistics.TeamVampireAlive == 0) {
                GameManager.Instance.RpcEndGame(GameOverReason.HumansByVote, false);
                return true;
            }
            return false;
        }

        private static void EndGameForSabotage(ShipStatus __instance) {
            GameManager.Instance.RpcEndGame(GameOverReason.ImpostorBySabotage, false);
            return;
        }

        private static bool CheckAndEndGameForJesterWin(ShipStatus __instance) {
            if (Jester.VotedOut && CustomGameOptions.NeutralEvilWinEndsGame) {
                GameManager.Instance.RpcEndGame((GameOverReason)CustomGameOverReason.JesterWin, false);
                return true;
            }
            return false;
        }
        private static bool CheckAndEndGameForExecutionerWin(ShipStatus __instance) {
            if (Executioner.TargetVotedOut && CustomGameOptions.NeutralEvilWinEndsGame) {
                GameManager.Instance.RpcEndGame((GameOverReason)CustomGameOverReason.ExecutionerWin, false);
                return true;
            }
            return false;
        }
        private static bool CheckAndEndGameForPhantomWin(ShipStatus __instance) {
            if (Phantom.CompletedTasks && CustomGameOptions.NeutralEvilWinEndsGame) {
                GameManager.Instance.RpcEndGame((GameOverReason)CustomGameOverReason.PhantomWin, false);
                return true;
            }
            return false;
        }
        private static bool CheckAndEndGameForDoomsayerWin(ShipStatus __instance) {
            if (Doomsayer.WonByGuessing && CustomGameOptions.NeutralEvilWinEndsGame) {
                GameManager.Instance.RpcEndGame((GameOverReason)CustomGameOverReason.DoomsayerWin, false);
                return true;
            }
            return false;
        }
        private static bool CheckAndEndGameForGlitchWin(ShipStatus __instance, PlayerStatistics statistics) {
            if (statistics.TotalAlive - statistics.TeamGlitchAlive <= statistics.TeamGlitchAlive && statistics.TeamImpostorsAlive == 0 && statistics.TeamArsonistAlive == 0 && statistics.TeamJuggernautAlive == 0 && statistics.TeamPlaguebearerAlive == 0 && statistics.TeamPestilenceAlive == 0 && statistics.TeamWerewolfAlive == 0 && statistics.TeamVampireAlive == 0 && statistics.TeamPowerCrewAlive == 0 && !(statistics.TeamGlitchHasAliveLover && statistics.TeamLoversAlive == 2)) {
                GameManager.Instance.RpcEndGame((GameOverReason)CustomGameOverReason.GlitchWin, false);
            }
            return false;   
        }
        private static bool CheckAndEndGameForArsonistWin(ShipStatus __instance, PlayerStatistics statistics) {
            if (statistics.TotalAlive - statistics.TeamArsonistAlive <= statistics.TeamArsonistAlive && statistics.TeamGlitchAlive == 0 && statistics.TeamImpostorsAlive == 0 && statistics.TeamJuggernautAlive == 0 && statistics.TeamPlaguebearerAlive == 0 && statistics.TeamPestilenceAlive == 0 && statistics.TeamWerewolfAlive == 0 && statistics.TeamVampireAlive == 0 && statistics.TeamPowerCrewAlive == 0 && !(statistics.TeamArsonistHasAliveLover && statistics.TeamLoversAlive == 2)) {
                GameManager.Instance.RpcEndGame((GameOverReason)CustomGameOverReason.ArsonistWin, false);
            }
            return false;   
        }
        private static bool CheckAndEndGameForJuggernautWin(ShipStatus __instance, PlayerStatistics statistics) {
            if (statistics.TotalAlive - statistics.TeamJuggernautAlive <= statistics.TeamJuggernautAlive && statistics.TeamGlitchAlive == 0 && statistics.TeamArsonistAlive == 0 && statistics.TeamImpostorsAlive == 0 && statistics.TeamPlaguebearerAlive == 0 && statistics.TeamPestilenceAlive == 0 && statistics.TeamWerewolfAlive == 0 && statistics.TeamVampireAlive == 0 && statistics.TeamPowerCrewAlive == 0 && !(statistics.TeamJuggernautHasAliveLover && statistics.TeamLoversAlive == 2)) {
                GameManager.Instance.RpcEndGame((GameOverReason)CustomGameOverReason.JuggernautWin, false);
            }
            return false;   
        }
        private static bool CheckAndEndGameForPlaguebearerWin(ShipStatus __instance, PlayerStatistics statistics) {
            if (statistics.TotalAlive - statistics.TeamPlaguebearerAlive <= statistics.TeamPlaguebearerAlive && statistics.TeamGlitchAlive == 0 && statistics.TeamArsonistAlive == 0 && statistics.TeamJuggernautAlive == 0 && statistics.TeamImpostorsAlive == 0 && statistics.TeamPestilenceAlive == 0 && statistics.TeamWerewolfAlive == 0 && statistics.TeamVampireAlive == 0 && statistics.TeamPowerCrewAlive == 0 && !(statistics.TeamPlaguebearerHasAliveLover && statistics.TeamLoversAlive == 2)) {
                GameManager.Instance.RpcEndGame((GameOverReason)CustomGameOverReason.PlaguebearerWin, false);
            }
            return false;   
        }
        private static bool CheckAndEndGameForPestilenceWin(ShipStatus __instance, PlayerStatistics statistics) {
            if (statistics.TotalAlive - statistics.TeamPestilenceAlive <= statistics.TeamPestilenceAlive && statistics.TeamGlitchAlive == 0 && statistics.TeamArsonistAlive == 0 && statistics.TeamJuggernautAlive == 0 && statistics.TeamPlaguebearerAlive == 0 && statistics.TeamImpostorsAlive == 0 && statistics.TeamWerewolfAlive == 0 && statistics.TeamVampireAlive == 0 && statistics.TeamPowerCrewAlive == 0 && !(statistics.TeamPestilenceHasAliveLover && statistics.TeamLoversAlive == 2)) {
                GameManager.Instance.RpcEndGame((GameOverReason)CustomGameOverReason.PestilenceWin, false);
            }
            return false;   
        }
        private static bool CheckAndEndGameForWerewolfWin(ShipStatus __instance, PlayerStatistics statistics) {
            if (statistics.TotalAlive - statistics.TeamWerewolfAlive <= statistics.TeamWerewolfAlive && statistics.TeamGlitchAlive == 0 && statistics.TeamArsonistAlive == 0 && statistics.TeamJuggernautAlive == 0 && statistics.TeamPlaguebearerAlive == 0 && statistics.TeamPestilenceAlive == 0 && statistics.TeamImpostorsAlive == 0 && statistics.TeamVampireAlive == 0 && statistics.TeamPowerCrewAlive == 0 && !(statistics.TeamWerewolfHasAliveLover && statistics.TeamLoversAlive == 2)) {
                GameManager.Instance.RpcEndGame((GameOverReason)CustomGameOverReason.WerewolfWin, false);
            }
            return false;   
        }
        private static bool CheckAndEndGameForVampireWin(ShipStatus __instance, PlayerStatistics statistics) {
            if (statistics.TotalAlive - statistics.TeamVampireAlive <= statistics.TeamVampireAlive && statistics.TeamGlitchAlive == 0 && statistics.TeamArsonistAlive == 0 && statistics.TeamJuggernautAlive == 0 && statistics.TeamPlaguebearerAlive == 0 && statistics.TeamPestilenceAlive == 0 && statistics.TeamWerewolfAlive == 0 && statistics.TeamImpostorsAlive == 0 && statistics.TeamPowerCrewAlive == 0 && !(statistics.TeamVampireHasAliveLover && statistics.TeamLoversAlive == 2)) {
                GameManager.Instance.RpcEndGame((GameOverReason)CustomGameOverReason.VampireWin, false);
            }
            return false;   
        }
        private static bool CheckAndEndGameForLoversWin(ShipStatus __instance, PlayerStatistics statistics) {
            if (statistics.TeamLoversAlive == 2 && statistics.TotalAlive <= 3) {
                GameManager.Instance.RpcEndGame((GameOverReason)CustomGameOverReason.LoversWin, false);
            }
            return false;   
        }
        private static bool CheckAndEndGameForSurvivorOnlyWin(ShipStatus __instance, PlayerStatistics statistics) {
            if (statistics.TotalAlive - statistics.TeamSurvivorAlive == 0 && !(statistics.TeamSurvivorHasAliveLover && statistics.TeamLoversAlive == 2)) {
                GameManager.Instance.RpcEndGame((GameOverReason)CustomGameOverReason.SurvivorOnlyWin, false);
            }
            return false;   
        }
    }

    internal class PlayerStatistics {
        public int TotalAlive {get;set;}
        public int TeamLoversAlive {get;set;}
        public int TeamImpostorsAlive {get;set;}
        public int TeamGlitchAlive {get;set;}
        public int TeamArsonistAlive {get;set;}
        public int TeamJuggernautAlive {get;set;}
        public int TeamPlaguebearerAlive {get;set;}
        public int TeamPestilenceAlive {get;set;}
        public int TeamWerewolfAlive {get;set;}
        public int TeamVampireAlive {get;set;}
        public int TeamSurvivorAlive {get;set;}
        public int TeamPowerCrewAlive {get;set;}

        public bool TeamImpostorsHasAliveLover {get;set;}
        public bool TeamGlitchHasAliveLover {get;set;}
        public bool TeamArsonistHasAliveLover {get;set;}
        public bool TeamJuggernautHasAliveLover {get;set;}
        public bool TeamPlaguebearerHasAliveLover {get;set;}
        public bool TeamPestilenceHasAliveLover {get;set;}
        public bool TeamWerewolfHasAliveLover {get;set;}
        public bool TeamVampireHasAliveLover {get;set;}
        public bool TeamSurvivorHasAliveLover {get;set;}

        public PlayerStatistics(ShipStatus __instance) {
            GetPlayerCounts();
        }

        private bool isLover(GameData.PlayerInfo p) {
            return Utils.IsLover(p.PlayerId);
        }

        private void GetPlayerCounts() {
            int numTotalAlive = 0;
            int numLoversAlive = 0;
            int teamImpostorsAlive = 0;
            int teamGlitchAlive = 0;
            int teamArsonistAlive = 0;
            int teamJuggernautAlive = 0;
            int teamPlaguebearerAlive = 0;
            int teamPestilenceAlive = 0;
            int teamWerewolfAlive = 0;
            int teamVampireAlive = 0;
            int teamSurvivorAlive = 0;
            int teamPowerCrewAlive = 0;

            bool teamImpostorsHasAliveLover = false;
            bool teamGlitchHasAliveLover = false;
            bool teamArsonistHasAliveLover = false;
            bool teamJuggernautHasAliveLover = false;
            bool teamPlaguebearerHasAliveLover = false;
            bool teamPestilenceHasAliveLover = false;
            bool teamWerewolfHasAliveLover = false;
            bool teamVampireHasAliveLover = false;
            bool teamSurvivorHasAliveLover = false;

            foreach (var playerInfo in GameData.Instance.AllPlayers.GetFastEnumerator()) {
                if (!playerInfo.Disconnected) {
                    if (!playerInfo.IsDead) {
                        numTotalAlive++;

                        bool lover = isLover(playerInfo);
                        if (lover) numLoversAlive++;

                        if (playerInfo.Role.IsImpostor) {
                            teamImpostorsAlive++;
                            if (lover) teamImpostorsHasAliveLover = true;
                        }

                        
                        foreach (var role in Role.GetRoles(RoleEnum.Glitch))
                        {
                            var Glitch = (Glitch)role;
                            if (Glitch.Player != null && Glitch.Player.PlayerId == playerInfo.PlayerId) {
                                teamGlitchAlive++;
                                if (lover) teamGlitchHasAliveLover = true;
                            }
                        }
                        
                        foreach (var role in Role.GetRoles(RoleEnum.Arsonist))
                        {
                            var Arsonist = (Arsonist)role;
                            if (Arsonist.Player != null && Arsonist.Player.PlayerId == playerInfo.PlayerId) {
                                teamArsonistAlive++;
                                if (lover) teamArsonistHasAliveLover = true;
                            }
                        }
                        
                        foreach (var role in Role.GetRoles(RoleEnum.Juggernaut))
                        {
                            var Juggernaut = (Juggernaut)role;
                            if (Juggernaut.Player != null && Juggernaut.Player.PlayerId == playerInfo.PlayerId) {
                                teamJuggernautAlive++;
                                if (lover) teamJuggernautHasAliveLover = true;
                            }
                        }
                        
                        foreach (var role in Role.GetRoles(RoleEnum.Plaguebearer))
                        {
                            var Plaguebearer = (Plaguebearer)role;
                            if (Plaguebearer.Player != null && Plaguebearer.Player.PlayerId == playerInfo.PlayerId) {
                                teamPlaguebearerAlive++;
                                if (lover) teamPlaguebearerHasAliveLover = true;
                            }
                        }
                        
                        foreach (var role in Role.GetRoles(RoleEnum.Pestilence))
                        {
                            var Pestilence = (Pestilence)role;
                            if (Pestilence.Player != null && Pestilence.Player.PlayerId == playerInfo.PlayerId) {
                                teamPestilenceAlive++;
                                if (lover) teamPestilenceHasAliveLover = true;
                            }
                        }
                        
                        foreach (var role in Role.GetRoles(RoleEnum.Werewolf))
                        {
                            var Werewolf = (Werewolf)role;
                            if (Werewolf.Player != null && Werewolf.Player.PlayerId == playerInfo.PlayerId) {
                                teamWerewolfAlive++;
                                if (lover) teamWerewolfHasAliveLover = true;
                            }
                        }
                        
                        foreach (var role in Role.GetRoles(RoleEnum.Vampire))
                        {
                            var Vampire = (Vampire)role;
                            if (Vampire.Player != null && Vampire.Player.PlayerId == playerInfo.PlayerId) {
                                teamVampireAlive++;
                                if (lover) teamVampireHasAliveLover = true;
                            }
                        }
                        
                        foreach (var role in Role.GetRoles(RoleEnum.Survivor))
                        {
                            var Survivor = (Survivor)role;
                            if (Survivor.Player != null && Survivor.Player.PlayerId == playerInfo.PlayerId) {
                                teamSurvivorAlive++;
                                if (lover) teamSurvivorHasAliveLover = true;
                            }
                        }

                        foreach (var role in Role.GetRoles(RoleEnum.Sheriff))
                        {
                            var sheriff = (Sheriff)role;
                            if (sheriff.Player != null && sheriff.Player.PlayerId == playerInfo.PlayerId) {
                                if (CustomGameOptions.BlockGameEnd && CustomGameOptions.SheriffBlockGameEnd) teamPowerCrewAlive++;
                            }
                        }

                        foreach (var role in Role.GetRoles(RoleEnum.Veteran))
                        {
                            var veteran = (Veteran)role;
                            if (veteran.Player != null && veteran.Player.PlayerId == playerInfo.PlayerId) {
                                if (CustomGameOptions.BlockGameEnd && CustomGameOptions.VeteranBlockGameEnd) teamPowerCrewAlive++;
                            }
                        }

                        foreach (var role in Role.GetRoles(RoleEnum.Mayor))
                        {
                            var mayor = (Mayor)role;
                            if (mayor.Player != null && mayor.Player.PlayerId == playerInfo.PlayerId) {
                                if (CustomGameOptions.BlockGameEnd && CustomGameOptions.MayorBlockGameEnd) teamPowerCrewAlive++;
                            }
                        }

                        foreach (var role in Role.GetRoles(RoleEnum.Swapper))
                        {
                            var swapper = (Swapper)role;
                            if (swapper.Player != null && swapper.Player.PlayerId == playerInfo.PlayerId) {
                                if (CustomGameOptions.BlockGameEnd && CustomGameOptions.SwapperBlockGameEnd) teamPowerCrewAlive++;
                            }
                        }

                        foreach (var modifier in Modifier.GetModifiers(ModifierEnum.Tiebreaker))
                        {
                            var tiebreaker = (Tiebreaker)modifier;
                            if (tiebreaker.Player != null && tiebreaker.Player.PlayerId == playerInfo.PlayerId && tiebreaker.Player.Is(Faction.Crewmates)) {
                                if (CustomGameOptions.BlockGameEnd && CustomGameOptions.TiebreakerBlockGameEnd) teamPowerCrewAlive++;
                            }
                        }
                    }
                }
            }

            TotalAlive = numTotalAlive;
            TeamLoversAlive = numLoversAlive;
            TeamImpostorsAlive = teamImpostorsAlive;
            TeamGlitchAlive = teamGlitchAlive;
            TeamArsonistAlive = teamArsonistAlive;
            TeamJuggernautAlive = teamJuggernautAlive;
            TeamPlaguebearerAlive = teamPlaguebearerAlive;
            TeamPestilenceAlive = teamPestilenceAlive;
            TeamWerewolfAlive = teamWerewolfAlive;
            TeamVampireAlive = teamVampireAlive;
            TeamSurvivorAlive = teamSurvivorAlive;
            TeamPowerCrewAlive = teamPowerCrewAlive;

            TeamImpostorsHasAliveLover = teamImpostorsHasAliveLover;
            TeamGlitchHasAliveLover = teamGlitchHasAliveLover;
            TeamArsonistHasAliveLover = teamArsonistHasAliveLover;
            TeamJuggernautHasAliveLover = teamJuggernautHasAliveLover;
            TeamPlaguebearerHasAliveLover = teamPlaguebearerHasAliveLover;
            TeamPestilenceHasAliveLover = teamPestilenceHasAliveLover;
            TeamWerewolfHasAliveLover = teamWerewolfHasAliveLover;
            TeamVampireHasAliveLover = teamVampireHasAliveLover;
            TeamSurvivorHasAliveLover = teamSurvivorHasAliveLover;
        }
    }
}