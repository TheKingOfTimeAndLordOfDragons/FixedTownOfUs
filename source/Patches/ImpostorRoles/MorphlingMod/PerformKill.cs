﻿using System;
using HarmonyLib;
using TownOfUs.Extensions;
using TownOfUs.Roles;
using UnityEngine;

namespace TownOfUs.ImpostorRoles.MorphlingMod
{
    [HarmonyPatch(typeof(KillButton), nameof(KillButton.DoClick))]
    public class PerformKill
    {
        public static Sprite SampleSprite => TownOfUs.SampleSprite;
        public static Sprite MorphSprite => TownOfUs.MorphSprite;

        public static bool Prefix(KillButton __instance)
        {
            var flag = PlayerControl.LocalPlayer.Is(RoleEnum.Morphling);
            if (!flag) return true;
            if (!PlayerControl.LocalPlayer.CanMove) return false;
            if (PlayerControl.LocalPlayer.Data.IsDead) return false;
            var role = Role.GetRole<Morphling>(PlayerControl.LocalPlayer);
            var target = role.ClosestPlayer;
            if (__instance == role.MorphButton)
            {
                if (!__instance.isActiveAndEnabled) return false;
                if (role.MorphButton.graphic.sprite == SampleSprite)
                {
                    if (target == null) return false;
                    role.SampledPlayer = target;
                    role.MorphButton.graphic.sprite = MorphSprite;
                    role.MorphButton.SetTarget(null);
                    DestroyableSingleton<HudManager>.Instance.KillButton.SetTarget(null);
                    if (role.MorphTimer() < 5f)
                        role.LastMorphed = DateTime.UtcNow.AddSeconds(5 - CustomGameOptions.MorphlingCd);
                    SoundEffectsManager.play("morphlingSample");
                }
                else
                {
                    if (__instance.isCoolingDown) return false;
                    if (role.MorphTimer() != 0) return false;
                    Utils.Rpc(CustomRPC.Morph, PlayerControl.LocalPlayer.PlayerId, role.SampledPlayer.PlayerId);
                    role.TimeRemaining = CustomGameOptions.MorphlingDuration;
                    role.MorphedPlayer = role.SampledPlayer;
                    Utils.Morph(role.Player, role.SampledPlayer, true);
                    SoundEffectsManager.play("morphlingMorph");
                }

                return false;
            }

            return true;
        }
    }
}
