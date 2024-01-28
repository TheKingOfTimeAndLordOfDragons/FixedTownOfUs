using HarmonyLib;
using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Hazel;
using TownOfUs.Roles;
using TownOfUs.Roles.Modifiers;
using TownOfUs.Extensions;

namespace TownOfUs.Patches
{
    [HarmonyPatch(typeof(IntroCutscene), nameof(IntroCutscene.OnDestroy))]
    class IntroCutsceneOnDestroyPatch
    {
        public static PoolablePlayer playerPrefab;
        public static Vector3 bottomLeft;
        
        public static void Prefix(IntroCutscene __instance) {
            // Generate and initialize player icons
            if (PlayerControl.LocalPlayer != null && DestroyableSingleton<HudManager>.Instance != null) {
                float aspect = Camera.main.aspect;
                float safeOrthographicSize = CameraSafeArea.GetSafeOrthographicSize(Camera.main);
                float xpos = 1.75f - safeOrthographicSize * aspect * 1.70f;
                float ypos = 0.15f - safeOrthographicSize * 1.7f;
                bottomLeft = new Vector3(xpos / 2, ypos/2, -61f);

                foreach (PlayerControl p in PlayerControl.AllPlayerControls) {
                    GameData.PlayerInfo data = p.Data;
                    PoolablePlayer player = UnityEngine.Object.Instantiate<PoolablePlayer>(__instance.PlayerPrefab, DestroyableSingleton<HudManager>.Instance.transform);
                    playerPrefab = __instance.PlayerPrefab;
                    p.SetPlayerMaterialColors(player.cosmetics.currentBodySprite.BodySprite);
                    player.SetSkin(data.DefaultOutfit.SkinId, data.DefaultOutfit.ColorId);
                    player.cosmetics.SetHat(data.DefaultOutfit.HatId, data.DefaultOutfit.ColorId);
                   // PlayerControl.SetPetImage(data.DefaultOutfit.PetId, data.DefaultOutfit.ColorId, player.PetSlot);
                    player.cosmetics.nameText.text = data.PlayerName;
                    player.SetFlipX(true);
                    Utils.playerIcons[p.PlayerId] = player;
                    player.gameObject.SetActive(false);

                    //  This can be done for all players not just for the bounty hunter as it was before. Allows the thief to have the correct position and scaling
                    player.transform.localPosition = bottomLeft;
                    player.transform.localScale = Vector3.one * 0.4f;
                    player.gameObject.SetActive(false);
                }
            }

            // Force Reload of SoundEffectHolder
            SoundEffectsManager.Load();
        }
    }

    [HarmonyPatch]
    class IntroPatch {
        public static void setupIntroTeamIcons(IntroCutscene __instance, ref  Il2CppSystem.Collections.Generic.List<PlayerControl> yourTeam) {
            // Intro solo teams
            if (PlayerControl.LocalPlayer.Is(Faction.NeutralBenign) || PlayerControl.LocalPlayer.Is(Faction.NeutralEvil) || PlayerControl.LocalPlayer.Is(Faction.NeutralKilling)) {
                var soloTeam = new Il2CppSystem.Collections.Generic.List<PlayerControl>();
                soloTeam.Add(PlayerControl.LocalPlayer);
                yourTeam = soloTeam;
            }
        }

        public static void setupIntroTeam(IntroCutscene __instance, ref  Il2CppSystem.Collections.Generic.List<PlayerControl> yourTeam) {
            if (PlayerControl.LocalPlayer.Is(Faction.NeutralBenign) || PlayerControl.LocalPlayer.Is(Faction.NeutralEvil) || PlayerControl.LocalPlayer.Is(Faction.NeutralKilling)) {
                var neutralColor = new Color32(76, 84, 78, 255);
                __instance.BackgroundBar.material.color = neutralColor;
                __instance.TeamTitle.text = Language.GetString("intro.faction.neutral");
                __instance.TeamTitle.color = neutralColor;
            }
        }

        public static IEnumerator<WaitForSeconds> EndShowRole(IntroCutscene __instance) {
            yield return new WaitForSeconds(5f);
            __instance.YouAreText.gameObject.SetActive(false);
            __instance.RoleText.gameObject.SetActive(false);
            __instance.RoleBlurbText.gameObject.SetActive(false);
            __instance.ourCrewmate.gameObject.SetActive(false);
           
        }

        [HarmonyPatch(typeof(IntroCutscene), nameof(IntroCutscene.CreatePlayer))]
        class CreatePlayerPatch {
            public static void Postfix(IntroCutscene __instance, bool impostorPositioning, ref PoolablePlayer __result) {
                if (impostorPositioning) __result.SetNameColor(Palette.ImpostorRed);
            }
        }


        [HarmonyPatch(typeof(IntroCutscene), nameof(IntroCutscene.ShowRole))]
        class SetUpRoleTextPatch {
            static int seed = 0;
            static public void SetRoleTexts(IntroCutscene __instance) {
                // Don't override the intro of the vanilla roles
                Role roleInfo = Role.GetRole(PlayerControl.LocalPlayer);
                Modifier modifierInfo = Modifier.GetModifier(PlayerControl.LocalPlayer);

                __instance.RoleBlurbText.text = "";
                if (roleInfo != null) {
                    __instance.RoleText.text = roleInfo.Name;
                    __instance.RoleText.color = roleInfo.Color;
                    __instance.RoleBlurbText.text = roleInfo.ImpostorText();
                    __instance.RoleBlurbText.color = roleInfo.Color;
                }
                if (modifierInfo != null) {
                    __instance.RoleBlurbText.text += Utils.cs(modifierInfo.Color, $"\n{modifierInfo.TaskText()}");
                }
            }
            public static bool Prefix(IntroCutscene __instance) {
                System.Random rnd = new System.Random((int)DateTime.Now.Ticks);
                seed = rnd.Next(5000);
                DestroyableSingleton<HudManager>.Instance.StartCoroutine(Effects.Lerp(1f, new Action<float>((p) => {
                    SetRoleTexts(__instance);
                })));
                return true;
            }
        }

        [HarmonyPatch(typeof(IntroCutscene), nameof(IntroCutscene.BeginCrewmate))]
        class BeginCrewmatePatch {
            public static void Prefix(IntroCutscene __instance, ref  Il2CppSystem.Collections.Generic.List<PlayerControl> teamToDisplay) {
                setupIntroTeamIcons(__instance, ref teamToDisplay);
            }

            public static void Postfix(IntroCutscene __instance, ref  Il2CppSystem.Collections.Generic.List<PlayerControl> teamToDisplay) {
                setupIntroTeam(__instance, ref teamToDisplay);
            }
        }

        [HarmonyPatch(typeof(IntroCutscene), nameof(IntroCutscene.BeginImpostor))]
        class BeginImpostorPatch {
            public static void Prefix(IntroCutscene __instance, ref  Il2CppSystem.Collections.Generic.List<PlayerControl> yourTeam) {
                setupIntroTeamIcons(__instance, ref yourTeam);
            }

            public static void Postfix(IntroCutscene __instance, ref  Il2CppSystem.Collections.Generic.List<PlayerControl> yourTeam) {
                setupIntroTeam(__instance, ref yourTeam);
            }
        }
    }
}