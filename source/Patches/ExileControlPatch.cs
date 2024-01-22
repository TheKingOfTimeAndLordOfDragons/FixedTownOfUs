using System;
using System.Linq;
using HarmonyLib;
using Reactor.Utilities;
using TownOfUs.CrewmateRoles.AltruistMod;
using TownOfUs.Patches.NeutralRoles;
using TownOfUs.Roles;
using UnityEngine;

namespace TownOfUs.Patches
{
    [HarmonyPatch(typeof(ExileController), nameof(ExileController.Begin))]
    [HarmonyPriority(Priority.First)]
    class ExileControllerPatch
    {
        public static ExileController lastExiled;
        public static GameData.PlayerInfo lastExiled1;
        public static void Prefix(ExileController __instance, [HarmonyArgument(0)]ref GameData.PlayerInfo exiled, [HarmonyArgument(1)]bool tie)
        {
            lastExiled = __instance;
            lastExiled1 = exiled;
        }
    }

    [HarmonyPatch]
    class ExileControllerWrapUpPatch {
        [HarmonyPatch(typeof(ExileController), nameof(ExileController.WrapUp))]
        class BaseExileControllerPatch {
            public static void Postfix(ExileController __instance) {
                WrapUpPostfix(__instance.exiled);
            }
        }

        [HarmonyPatch(typeof(AirshipExileController), nameof(AirshipExileController.WrapUpAndSpawn))]
        class AirshipExileControllerPatch {
            public static void Postfix(AirshipExileController __instance) {
                WrapUpPostfix(__instance.exiled);
            }
        }

        // Workaround to add a "postfix" to the destroying of the exile controller (i.e. cutscene) and SpwanInMinigame of submerged
        [HarmonyPatch(typeof(UnityEngine.Object), nameof(UnityEngine.Object.Destroy), new Type[] { typeof(GameObject) })]
        public static void Prefix(GameObject obj) {
            // submerged
            if (!SubmergedCompatibility.isSubmerged()) return;
            if (obj.name.Contains("ExileCutscene")) {
                WrapUpPostfix(ExileControllerPatch.lastExiled1);
            }
        }

        static void WrapUpPostfix(GameData.PlayerInfo exiled) {
            // Executioner Win Condition
            foreach (var role in Role.GetRoles(RoleEnum.Executioner))
            {
                var exe = (Executioner)role;
                if (exiled != null && exe.Player != null && exe.target != null && exe.target.PlayerId == exiled.PlayerId && !exe.Player.Data.IsDead) {
                    Executioner.TargetVotedOut = true;

                    if (!CustomGameOptions.NeutralEvilWinEndsGame) {
                        KillButtonTarget.DontRevive = role.Player.PlayerId;
                        role.Player.Exiled();
                        if (CustomGameOptions.ExecutionerTorment && PlayerControl.LocalPlayer == role.Player) {
                            byte[] toKill = MeetingHud.Instance.playerStates.Where(x => !Utils.PlayerById(x.TargetPlayerId).Is(RoleEnum.Pestilence) && x.VotedFor == ((Executioner)role).target.PlayerId).Select(x => x.TargetPlayerId).ToArray();
                            var pk = new PunishmentKill((x) => {
                                Utils.RpcMultiMurderPlayer(role.Player, x);
                            }, (y) => {
                                return toKill.Contains(y.PlayerId);
                            });
                            Coroutines.Start(pk.Open(3f));
                        }
                    }
                }
            }

            // Jester Win Condition
            foreach (var role in Role.GetRoles(RoleEnum.Jester))
            {
                var jester = (Jester)role;
                if (exiled != null && jester.Player != null && jester.Player.PlayerId == exiled.PlayerId) {
                    Jester.VotedOut = true;

                    if (!CustomGameOptions.NeutralEvilWinEndsGame && CustomGameOptions.JesterHaunt) {
                        if (PlayerControl.LocalPlayer == role.Player) {
                            byte[] toKill = MeetingHud.Instance.playerStates.Where(x => !Utils.PlayerById(x.TargetPlayerId).Is(RoleEnum.Pestilence) && x.VotedFor == role.Player.PlayerId).Select(x => x.TargetPlayerId).ToArray();
                            var pk = new PunishmentKill((x) =>
                            {
                                Utils.RpcMultiMurderPlayer(role.Player, x);
                            }, (y) =>
                            {
                                return toKill.Contains(y.PlayerId);
                            });
                            Coroutines.Start(pk.Open(3f));
                        }
                    }
                }
            }
        }
    }
}