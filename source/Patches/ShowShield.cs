using AmongUs.GameOptions;
using HarmonyLib;
using TownOfUs.Extensions;
using TownOfUs.Roles;
using UnityEngine;
using NeutralRole = TownOfUs.NeutralRoles;

namespace TownOfUs.Patches
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public class ShowRoundOneShield
    {
        public static Color ShieldColor = Color.green;
        public static string DiedFirst = "";
        public static PlayerControl FirstRoundShielded = null;
    }

    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.FixedUpdate))]
    public static class PlayerControlFixedUpdatePatch
    {
        static void setBasePlayerOutlines() {
            foreach (PlayerControl target in PlayerControl.AllPlayerControls) {
                if (target == null || target.cosmetics?.currentBodySprite?.BodySprite == null) continue;

                bool isMorphedMorphling = false;
                foreach (var morphlingRole in Role.GetRoles(RoleEnum.Morphling))
                {
                    var morphling = (Morphling)morphlingRole;
                    isMorphedMorphling = target == morphling.Player && morphling.MorphedPlayer != null && morphling.Morphed;
                }
                bool isMorphedGlitch = false;
                foreach (var glitchRole in Role.GetRoles(RoleEnum.Glitch))
                {
                    var glitch = (Glitch)glitchRole;
                    isMorphedGlitch = target == glitch.Player && glitch.MimicTarget != null && glitch.IsUsingMimic;
                }
                bool isMorphedVenerer = false;
                foreach (var venererRole in Role.GetRoles(RoleEnum.Venerer))
                {
                    var venerer = (Venerer)venererRole;
                    isMorphedVenerer = target == venerer.Player && venerer.Enabled;
                }
                bool isSwoopedSwooper = false;
                foreach (var swooperRole in Role.GetRoles(RoleEnum.Swooper))
                {
                    var swooper = (Swooper)swooperRole;
                    isSwoopedSwooper = target == swooper.Player && swooper.Enabled;
                }

                bool hasVisibleShield = false;
                Color color = Color.cyan;

                if (!CamouflageUnCamouflage.IsCamoed && ShowRoundOneShield.FirstRoundShielded != null && CustomGameOptions.FirstDeathShield && ((target == ShowRoundOneShield.FirstRoundShielded && !isMorphedMorphling && !isMorphedGlitch && !isMorphedVenerer && !isSwoopedSwooper) || (isMorphedMorphling && Role.GetRole<Morphling>(target).MorphedPlayer == ShowRoundOneShield.FirstRoundShielded) || (isMorphedGlitch && Role.GetRole<Glitch>(target).MimicTarget == ShowRoundOneShield.FirstRoundShielded))) {
                    hasVisibleShield = true;
                    color = ShowRoundOneShield.ShieldColor;
                }

                foreach (var medicRole in Role.GetRoles(RoleEnum.Medic))
                {
                    var medic = (Medic)medicRole;

                    if (!CamouflageUnCamouflage.IsCamoed && medic.Player != null && medic.ShieldedPlayer != null && ((target == medic.ShieldedPlayer && !isMorphedMorphling && !isMorphedGlitch && !isMorphedVenerer && !isSwoopedSwooper) || (isMorphedMorphling && Role.GetRole<Morphling>(target).MorphedPlayer == medic.ShieldedPlayer) || (isMorphedGlitch && Role.GetRole<Glitch>(target).MimicTarget == medic.ShieldedPlayer))) {
                        hasVisibleShield = CustomGameOptions.ShowShielded == CrewmateRoles.MedicMod.ShieldOptions.Everyone // Everyone
                            || CustomGameOptions.ShowShielded == CrewmateRoles.MedicMod.ShieldOptions.Medic && PlayerControl.LocalPlayer == medic.Player // Medic Only
                            || CustomGameOptions.ShowShielded == CrewmateRoles.MedicMod.ShieldOptions.Self && PlayerControl.LocalPlayer == medic.ShieldedPlayer // Shield only
                            || CustomGameOptions.ShowShielded == CrewmateRoles.MedicMod.ShieldOptions.SelfAndMedic && (PlayerControl.LocalPlayer == medic.Player || PlayerControl.LocalPlayer == medic.ShieldedPlayer); // Medic + Shield
                        color = Color.cyan;
                    }
                }

                foreach (var gaRole in Role.GetRoles(RoleEnum.GuardianAngel))
                {
                    var ga = (GuardianAngel)gaRole;

                    if (!CamouflageUnCamouflage.IsCamoed && ga.Protecting && ga.Player != null && ga.target != null && ((target == ga.target && !isMorphedMorphling && !isMorphedGlitch && !isMorphedVenerer && !isSwoopedSwooper) || (isMorphedMorphling && Role.GetRole<Morphling>(target).MorphedPlayer == ga.target) || (isMorphedGlitch && Role.GetRole<Glitch>(target).MimicTarget == ga.target))) {
                        hasVisibleShield = CustomGameOptions.ShowProtect == NeutralRole.GuardianAngelMod.ProtectOptions.Everyone // Everyone
                            || CustomGameOptions.ShowProtect == NeutralRole.GuardianAngelMod.ProtectOptions.GA && PlayerControl.LocalPlayer == ga.Player // GA Only
                            || CustomGameOptions.ShowProtect == NeutralRole.GuardianAngelMod.ProtectOptions.Self && PlayerControl.LocalPlayer == ga.target // target only
                            || CustomGameOptions.ShowProtect == NeutralRole.GuardianAngelMod.ProtectOptions.SelfAndGA && (PlayerControl.LocalPlayer == ga.Player || PlayerControl.LocalPlayer == ga.target); // ga + target
                        color = Color.yellow;
                    }
                }

                foreach (var arsoRole in Role.GetRoles(RoleEnum.Arsonist))
                {
                    var arsonist = (Arsonist)arsoRole;

                    foreach (var player in arsonist.DousedPlayers)
                    {
                        PlayerControl dousedPlayer = Utils.PlayerById(player);

                        if (!CamouflageUnCamouflage.IsCamoed && arsonist.Player != null && dousedPlayer != null && ((target == dousedPlayer && !isMorphedMorphling && !isMorphedGlitch && !isMorphedVenerer && !isSwoopedSwooper) || (isMorphedMorphling && Role.GetRole<Morphling>(target).MorphedPlayer == dousedPlayer) || (isMorphedGlitch && Role.GetRole<Glitch>(target).MimicTarget == dousedPlayer))) {
                            hasVisibleShield = PlayerControl.LocalPlayer == arsonist.Player;
                            color = arsonist.Color;
                        }
                    }
                }

                if (hasVisibleShield) {
                    target.cosmetics.currentBodySprite.BodySprite.material.SetFloat("_Outline", 1f);
                    target.cosmetics.currentBodySprite.BodySprite.material.SetColor("_OutlineColor", color);
                    target.cosmetics.currentBodySprite.BodySprite.material.SetColor("_VisorColor", color);
                }
            }
        }

        public static void Postfix(PlayerControl __instance) {
            if (AmongUsClient.Instance.GameState != InnerNet.InnerNetClient.GameStates.Started || GameOptionsManager.Instance.currentGameOptions.GameMode == GameModes.HideNSeek) return;
            
            if (PlayerControl.LocalPlayer == __instance) {
                // Update player outlines
                setBasePlayerOutlines();
            }
        }
    }
}