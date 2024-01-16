using HarmonyLib;
using Hazel;
using TownOfUs.Extensions;
using TownOfUs.Roles;
using TownOfUs.Roles.Modifiers;
using UnityEngine;
using NeutralRole = TownOfUs.NeutralRoles;

namespace TownOfUs.Patches
{
    [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.Start))]
    public class MeetingStart
    {
        public static void Postfix(MeetingHud __instance)
        {
            if (ShowRoundOneShield.FirstRoundShielded != null && !ShowRoundOneShield.FirstRoundShielded.Data.Disconnected)
            {
                ShowRoundOneShield.FirstRoundShielded.myRend().material.SetColor("_VisorColor", Palette.VisorColor);
                ShowRoundOneShield.FirstRoundShielded.myRend().material.SetFloat("_Outline", 0f);
                ShowRoundOneShield.FirstRoundShielded = null;
            }
        }
    }

    [HarmonyPatch]
    class MeetingHudPatch {
        [HarmonyPatch(typeof(PlayerVoteArea), nameof(PlayerVoteArea.Select))]
        class PlayerVoteAreaSelectPatch {
            static bool Prefix(MeetingHud __instance) {
                return !(PlayerControl.LocalPlayer != null && PlayerControl.LocalPlayer.Is(RoleEnum.Vigilante) && CrewmateRoles.VigilanteMod.AddButton.vigilanteUI != null) ||
                     !(PlayerControl.LocalPlayer != null && PlayerControl.LocalPlayer.Is(RoleEnum.Doomsayer) && NeutralRole.DoomsayerMod.AddButton.doomsayerUI != null) ||
                     !(PlayerControl.LocalPlayer != null && PlayerControl.LocalPlayer.Is(AbilityEnum.Assassin) && Modifiers.AssassinMod.AddButton.assassinUI != null);
            }
        }

        static void populateButtonsPostfix(MeetingHud __instance) {
            if (PlayerControl.LocalPlayer.Is(RoleEnum.Vigilante) && !PlayerControl.LocalPlayer.Data.IsDead && Role.GetRole<Vigilante>(PlayerControl.LocalPlayer).RemainingKills > 0)
            {
                for (int i = 0; i < __instance.playerStates.Length; i++)
                {
                    PlayerVoteArea playerVoteArea = __instance.playerStates[i];
                    if (CrewmateRoles.VigilanteMod.AddButton.IsExempt(playerVoteArea)) continue;
                    if (Utils.PlayerById(playerVoteArea.TargetPlayerId).Is(RoleEnum.Mayor) && Role.GetRole<Mayor>(Utils.PlayerById(playerVoteArea.TargetPlayerId)).Revealed) continue;

                    GameObject template = playerVoteArea.Buttons.transform.Find("CancelButton").gameObject;
                    GameObject targetBox = UnityEngine.Object.Instantiate(template, playerVoteArea.transform);
                    targetBox.name = "ShootButton";
                    targetBox.transform.localPosition = new Vector3(-0.95f, 0.03f, -1.3f);
                    SpriteRenderer renderer = targetBox.GetComponent<SpriteRenderer>();
                    renderer.sprite = TownOfUs.TargetIcon;
                    PassiveButton button = targetBox.GetComponent<PassiveButton>();
                    button.OnClick.RemoveAllListeners();
                    int copiedIndex = i;
                    button.OnClick.AddListener((System.Action)(() => CrewmateRoles.VigilanteMod.AddButton.vigilanteOnClick(copiedIndex, __instance)));
                }
            }

            if (PlayerControl.LocalPlayer.Is(RoleEnum.Doomsayer) && !PlayerControl.LocalPlayer.Data.IsDead)
            {
                for (int i = 0; i < __instance.playerStates.Length; i++)
                {
                    PlayerVoteArea playerVoteArea = __instance.playerStates[i];
                    if (NeutralRole.DoomsayerMod.AddButton.IsExempt(playerVoteArea)) continue;
                    if (Utils.PlayerById(playerVoteArea.TargetPlayerId).Is(RoleEnum.Mayor) && Role.GetRole<Mayor>(Utils.PlayerById(playerVoteArea.TargetPlayerId)).Revealed) continue;

                    GameObject template = playerVoteArea.Buttons.transform.Find("CancelButton").gameObject;
                    GameObject targetBox = UnityEngine.Object.Instantiate(template, playerVoteArea.transform);
                    targetBox.name = "ShootButton";
                    targetBox.transform.localPosition = new Vector3(-0.95f, 0.03f, -1.3f);
                    SpriteRenderer renderer = targetBox.GetComponent<SpriteRenderer>();
                    renderer.sprite = TownOfUs.TargetIcon;
                    PassiveButton button = targetBox.GetComponent<PassiveButton>();
                    button.OnClick.RemoveAllListeners();
                    int copiedIndex = i;
                    button.OnClick.AddListener((System.Action)(() => NeutralRole.DoomsayerMod.AddButton.doomsayerOnClick(copiedIndex, __instance)));
                }
            }

            if (PlayerControl.LocalPlayer.Is(AbilityEnum.Assassin) && !PlayerControl.LocalPlayer.Data.IsDead && Ability.GetAbility<Assassin>(PlayerControl.LocalPlayer).RemainingKills > 0)
            {
                for (int i = 0; i < __instance.playerStates.Length; i++)
                {
                    PlayerVoteArea playerVoteArea = __instance.playerStates[i];
                    if (Modifiers.AssassinMod.AddButton.IsExempt(playerVoteArea)) continue;
                    if (Utils.PlayerById(playerVoteArea.TargetPlayerId).Is(RoleEnum.Mayor) && Role.GetRole<Mayor>(Utils.PlayerById(playerVoteArea.TargetPlayerId)).Revealed) continue;

                    GameObject template = playerVoteArea.Buttons.transform.Find("CancelButton").gameObject;
                    GameObject targetBox = UnityEngine.Object.Instantiate(template, playerVoteArea.transform);
                    targetBox.name = "ShootButton";
                    targetBox.transform.localPosition = new Vector3(-0.95f, 0.03f, -1.3f);
                    SpriteRenderer renderer = targetBox.GetComponent<SpriteRenderer>();
                    renderer.sprite = TownOfUs.TargetIcon;
                    PassiveButton button = targetBox.GetComponent<PassiveButton>();
                    button.OnClick.RemoveAllListeners();
                    int copiedIndex = i;
                    button.OnClick.AddListener((System.Action)(() => Modifiers.AssassinMod.AddButton.assassinOnClick(copiedIndex, __instance)));
                }
            }
        }

        [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.ServerStart))]
        class MeetingServerStartPatch {
            static void Postfix(MeetingHud __instance)
            {
                populateButtonsPostfix(__instance);
            }
        }

        [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.Deserialize))]
        class MeetingDeserializePatch {
            static void Postfix(MeetingHud __instance, [HarmonyArgument(0)]MessageReader reader, [HarmonyArgument(1)]bool initialState)
            {
                if (initialState) {
                    populateButtonsPostfix(__instance);
                }
            }
        }
    }
}