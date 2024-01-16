using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using Reactor.Utilities;
using TownOfUs.Extensions;
using TownOfUs.Roles;
using TownOfUs.Roles.Modifiers;
using UnityEngine;

namespace TownOfUs.Modifiers.AssassinMod
{
    [HarmonyPatch]
    public class AddButton
    {
        public static GameObject assassinUI;
        public static PassiveButton assassinUIExitButton;
        public static byte assassinCurrentTarget;
        public static bool IsExempt(PlayerVoteArea voteArea)
        {
            if (voteArea.AmDead) return true;
            var player = Utils.PlayerById(voteArea.TargetPlayerId);
            if (PlayerControl.LocalPlayer.Is(RoleEnum.Vampire))
            {
                if (
                    player == null ||
                    player.Is(RoleEnum.Vampire) ||
                    player.Data.IsDead ||
                    player.Data.Disconnected
                ) return true;
            }
            else if (PlayerControl.LocalPlayer.Is(Faction.NeutralKilling))
            {
                if (
                    player == null ||
                    player.Data.IsDead ||
                    player.Data.Disconnected
                ) return true;
            }
            else
            {
                if (
                    player == null ||
                    player.Data.IsImpostor() ||
                    player.Data.IsDead ||
                    player.Data.Disconnected
                ) return true;
            }
            var role = Role.GetRole(player);
            return role != null && role.Criteria();
        }

        public static void assassinOnClick(int buttonTarget, MeetingHud __instance) {
            var ability = Ability.GetAbility<Assassin>(PlayerControl.LocalPlayer);
            if (assassinUI != null || !(__instance.state == MeetingHud.VoteStates.Voted || __instance.state == MeetingHud.VoteStates.NotVoted)) return;
            __instance.playerStates.ToList().ForEach(x => x.gameObject.SetActive(false));

            Transform PhoneUI = UnityEngine.Object.FindObjectsOfType<Transform>().FirstOrDefault(x => x.name == "PhoneUI");
            Transform container = UnityEngine.Object.Instantiate(PhoneUI, __instance.transform);
            container.transform.localPosition = new Vector3(0, 0, -5f);
            assassinUI = container.gameObject;

            int i = 0;
            var buttonTemplate = __instance.playerStates[0].transform.FindChild("votePlayerBase");
            var maskTemplate = __instance.playerStates[0].transform.FindChild("MaskArea");
            var smallButtonTemplate = __instance.playerStates[0].Buttons.transform.Find("CancelButton");
            var textTemplate = __instance.playerStates[0].NameText;

            assassinCurrentTarget = __instance.playerStates[buttonTarget].TargetPlayerId;

            Transform exitButtonParent = (new GameObject()).transform;
            exitButtonParent.SetParent(container);
            Transform exitButton = UnityEngine.Object.Instantiate(buttonTemplate.transform, exitButtonParent);
            Transform exitButtonMask = UnityEngine.Object.Instantiate(maskTemplate, exitButtonParent);
            exitButton.gameObject.GetComponent<SpriteRenderer>().sprite = smallButtonTemplate.GetComponent<SpriteRenderer>().sprite;
            exitButtonParent.transform.localPosition = new Vector3(2.725f, 2.1f, -5);
            exitButtonParent.transform.localScale = new Vector3(0.217f, 0.9f, 1);
            assassinUIExitButton = exitButton.GetComponent<PassiveButton>();
            assassinUIExitButton.OnClick.RemoveAllListeners();
            assassinUIExitButton.OnClick.AddListener((System.Action)(() => {
                __instance.playerStates.ToList().ForEach(x => {
                    x.gameObject.SetActive(true);
                    if (PlayerControl.LocalPlayer.Data.IsDead && x.transform.FindChild("ShootButton") != null) UnityEngine.Object.Destroy(x.transform.FindChild("ShootButton").gameObject);
                });
                UnityEngine.Object.Destroy(container.gameObject);
            }));

            List<Transform> buttons = new List<Transform>();
            Transform selectedButton = null;

            foreach (var pair in ability.SortedColorMapping) {
                Transform buttonParent = (new GameObject()).transform;
                buttonParent.SetParent(container);
                Transform button = UnityEngine.Object.Instantiate(buttonTemplate, buttonParent);
                Transform buttonMask = UnityEngine.Object.Instantiate(maskTemplate, buttonParent);
                TMPro.TextMeshPro label = UnityEngine.Object.Instantiate(textTemplate, button);
                button.GetComponent<SpriteRenderer>().sprite = ShipStatus.Instance.CosmeticsCache.GetNameplate("nameplate_NoPlate").Image;
                buttons.Add(button);
                int row = i/5, col = i%5;
                buttonParent.localPosition = new Vector3(-3.47f + 1.75f * col, 1.5f - 0.45f * row, -5);
                buttonParent.localScale = new Vector3(0.55f, 0.55f, 1f);
                label.text = Utils.cs(pair.Value, pair.Key);
                label.alignment = TMPro.TextAlignmentOptions.Center;
                label.transform.localPosition = new Vector3(0, 0, label.transform.localPosition.z);
                label.transform.localScale *= 1.7f;
                int copiedIndex = i;

                button.GetComponent<PassiveButton>().OnClick.RemoveAllListeners();
                if (!PlayerControl.LocalPlayer.Data.IsDead && !Utils.PlayerById((byte)__instance.playerStates[buttonTarget].TargetPlayerId).Data.IsDead) button.GetComponent<PassiveButton>().OnClick.AddListener((System.Action)(() => {
                    if (selectedButton != button) {
                        selectedButton = button;
                        buttons.ForEach(x => x.GetComponent<SpriteRenderer>().color = x == selectedButton ? Color.red : Color.white);
                    } else {
                        PlayerControl focusedTarget = Utils.PlayerById((byte)__instance.playerStates[buttonTarget].TargetPlayerId);
                        if (!(__instance.state == MeetingHud.VoteStates.Voted || __instance.state == MeetingHud.VoteStates.NotVoted) || focusedTarget == null || ability.RemainingKills <= 0 ) return;

                        var mainRoleInfo = Role.GetRole(focusedTarget);
                        var modRoleInfo = Modifier.GetModifier(focusedTarget);

                        PlayerControl dyingTarget = (mainRoleInfo.Name == pair.Key) ? focusedTarget : PlayerControl.LocalPlayer;
                        if (modRoleInfo != null)
                            dyingTarget = (mainRoleInfo.Name == pair.Key || modRoleInfo.Name == pair.Key) ? focusedTarget : PlayerControl.LocalPlayer;
                        // Reset the GUI
                        __instance.playerStates.ToList().ForEach(x => x.gameObject.SetActive(true));
                        UnityEngine.Object.Destroy(container.gameObject);
                        if (CustomGameOptions.AssassinMultiKill && ability.RemainingKills > 1 && dyingTarget != PlayerControl.LocalPlayer)
                            __instance.playerStates.ToList().ForEach(x => { if (x.TargetPlayerId == dyingTarget.PlayerId && x.transform.FindChild("ShootButton") != null) UnityEngine.Object.Destroy(x.transform.FindChild("ShootButton").gameObject); });
                        else
                            __instance.playerStates.ToList().ForEach(x => { if (x.transform.FindChild("ShootButton") != null) UnityEngine.Object.Destroy(x.transform.FindChild("ShootButton").gameObject); });

                        // Shoot player
                        if (!dyingTarget.Is(RoleEnum.Pestilence) || PlayerControl.LocalPlayer.Is(RoleEnum.Pestilence))
                        {
                            if (PlayerControl.LocalPlayer.Is(ModifierEnum.DoubleShot) && dyingTarget == PlayerControl.LocalPlayer)
                            {
                                var modifier = Modifier.GetModifier<DoubleShot>(PlayerControl.LocalPlayer);
                                if (modifier.LifeUsed == false)
                                {
                                    modifier.LifeUsed = true;
                                    Coroutines.Start(Utils.FlashCoroutine(Color.red, 1f));
                                    __instance.playerStates.ToList().ForEach(x => { if (x.TargetPlayerId == dyingTarget.PlayerId && x.transform.FindChild("ShootButton") != null) UnityEngine.Object.Destroy(x.transform.FindChild("ShootButton").gameObject); });
                                }
                                else
                                {
                                    AssassinKill.RpcMurderPlayer(ability, dyingTarget, PlayerControl.LocalPlayer);
                                    ability.RemainingKills--;
                                    if (dyingTarget.IsLover() && CustomGameOptions.BothLoversDie)
                                    {
                                        var lover = ((Lover)modRoleInfo).OtherLover.Player;
                                        if (!lover.Is(RoleEnum.Pestilence)) 
                                            __instance.playerStates.ToList().ForEach(x => { if (x.TargetPlayerId == lover.PlayerId && x.transform.FindChild("ShootButton") != null) UnityEngine.Object.Destroy(x.transform.FindChild("ShootButton").gameObject); });
                                    }
                                }
                            }
                            else
                            {
                                AssassinKill.RpcMurderPlayer(ability, dyingTarget, PlayerControl.LocalPlayer);
                                ability.RemainingKills--;
                                if (dyingTarget.IsLover() && CustomGameOptions.BothLoversDie)
                                {
                                    var lover = ((Lover)modRoleInfo).OtherLover.Player;
                                    if (!lover.Is(RoleEnum.Pestilence))
                                        __instance.playerStates.ToList().ForEach(x => { if (x.TargetPlayerId == lover.PlayerId && x.transform.FindChild("ShootButton") != null) UnityEngine.Object.Destroy(x.transform.FindChild("ShootButton").gameObject); });
                                }
                            }
                        }
                    }
                }));
                i++;
            }
            container.transform.localScale *= 0.75f;
        }
    }
}
