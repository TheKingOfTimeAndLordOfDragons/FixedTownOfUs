using System.Collections.Generic;
using TownOfUs.Roles;
using TownOfUs.Roles.Modifiers;
using UnityEngine;
using System;

namespace TownOfUs.Extensions
{
public static class MapUtilities
{
    public static ShipStatus CachedShipStatus = ShipStatus.Instance;

    public static void MapDestroyed()
    {
        CachedShipStatus = ShipStatus.Instance;
        _systems.Clear();
    }

    private static readonly Dictionary<SystemTypes, Il2CppSystem.Object> _systems = new();
    public static Dictionary<SystemTypes, Il2CppSystem.Object> Systems
    {
        get
        {
            if (_systems.Count == 0) GetSystems();
            return _systems;
        }
    }

    private static void GetSystems()
    {
        if (!CachedShipStatus) return;

        var systems = CachedShipStatus.Systems;
        if (systems.Count <= 0) return;
        
        foreach (var systemTypes in SystemTypeHelpers.AllTypes)
        {
            if (!systems.ContainsKey(systemTypes)) continue;
            _systems[systemTypes] = systems[systemTypes].TryCast<Il2CppSystem.Object>();
        }
    }
}
    public static class AmongUsExtensions
    {
        public static KeyValuePair<byte, int> MaxPair(this Dictionary<byte, int> self, out bool tie)
        {
            tie = true;
            var result = new KeyValuePair<byte, int>(byte.MaxValue, int.MinValue);
            foreach (var keyValuePair in self)
                if (keyValuePair.Value > result.Value)
                {
                    result = keyValuePair;
                    tie = false;
                }
                else if (keyValuePair.Value == result.Value)
                {
                    tie = true;
                }

            return result;
        }

        public static KeyValuePair<byte, int> MaxPair(this byte[] self, out bool tie)
        {
            tie = true;
            var result = new KeyValuePair<byte, int>(byte.MaxValue, int.MinValue);
            for (byte i = 0; i < self.Length; i++)
                if (self[i] > result.Value)
                {
                    result = new KeyValuePair<byte, int>(i, self[i]);
                    tie = false;
                }
                else if (self[i] == result.Value)
                {
                    tie = true;
                }

            return result;
        }

        public static VisualAppearance GetDefaultAppearance(this PlayerControl player)
        {
            return new VisualAppearance();
        }

        public static bool TryGetAppearance(this PlayerControl player, IVisualAlteration modifier, out VisualAppearance appearance)
        {
            if (modifier != null)
                return modifier.TryGetModifiedAppearance(out appearance);

            appearance = player.GetDefaultAppearance();
            return false;
        }

        public static VisualAppearance GetAppearance(this PlayerControl player)
        {
            if (player.TryGetAppearance(Role.GetRole(player) as IVisualAlteration, out var appearance))
                return appearance;
            else if (player.TryGetAppearance(Modifier.GetModifier(player) as IVisualAlteration, out appearance))
                return appearance;
            else
                return player.GetDefaultAppearance();
        }
        public static bool IsImpostor(this GameData.PlayerInfo playerinfo)
        {
            return playerinfo?.Role?.TeamType == RoleTeamTypes.Impostor;
        }

        public static void SetImpostor(this GameData.PlayerInfo playerinfo, bool impostor)
        {
            if (playerinfo.Role != null)
                playerinfo.Role.TeamType = impostor ? RoleTeamTypes.Impostor : RoleTeamTypes.Crewmate;
        }

        public static GameData.PlayerOutfit GetDefaultOutfit(this PlayerControl playerControl)
        {
            return playerControl.Data.DefaultOutfit;
        }

        public static void SetOutfit(this PlayerControl playerControl, CustomPlayerOutfitType CustomOutfitType, GameData.PlayerOutfit outfit)
        {
            playerControl.Data.SetOutfit((PlayerOutfitType)CustomOutfitType, outfit);
            playerControl.SetOutfit(CustomOutfitType);
        }
        public static void SetOutfit(this PlayerControl playerControl, CustomPlayerOutfitType CustomOutfitType)
        {
            var outfitType = (PlayerOutfitType)CustomOutfitType;
            if (!playerControl.Data.Outfits.ContainsKey(outfitType))
            {
                return;
            }
            var newOutfit = playerControl.Data.Outfits[outfitType];
            playerControl.CurrentOutfitType = outfitType;

            playerControl.RawSetName(newOutfit.PlayerName);
            playerControl.RawSetColor(newOutfit.ColorId);
            playerControl.RawSetVisor(newOutfit.VisorId, newOutfit.ColorId);
            playerControl.RawSetHat(newOutfit.HatId, newOutfit.ColorId);

            if (!playerControl.Data.IsDead) playerControl.RawSetPet(newOutfit.PetId, newOutfit.ColorId);
            if (!playerControl.Data.IsDead) {
                SkinViewData nextSkin = null;
                try { nextSkin = ShipStatus.Instance.CosmeticsCache.GetSkin(newOutfit.SkinId); } catch { return; };
                
                PlayerPhysics playerPhysics = playerControl.MyPhysics;
                AnimationClip clip = null;
                var spriteAnim = playerPhysics.myPlayer.cosmetics.skin.animator;
                var currentPhysicsAnim = playerPhysics.Animations.Animator.GetCurrentAnimation();


                if (currentPhysicsAnim == playerPhysics.Animations.group.RunAnim) clip = nextSkin.RunAnim;
                else if (currentPhysicsAnim == playerPhysics.Animations.group.SpawnAnim) clip = nextSkin.SpawnAnim;
                else if (currentPhysicsAnim == playerPhysics.Animations.group.EnterVentAnim) clip = nextSkin.EnterVentAnim;
                else if (currentPhysicsAnim == playerPhysics.Animations.group.ExitVentAnim) clip = nextSkin.ExitVentAnim;
                else if (currentPhysicsAnim == playerPhysics.Animations.group.IdleAnim) clip = nextSkin.IdleAnim;
                else clip = nextSkin.IdleAnim;
                float progress = playerPhysics.Animations.Animator.m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
                playerPhysics.myPlayer.cosmetics.skin.skin = nextSkin;
                playerPhysics.myPlayer.cosmetics.skin.UpdateMaterial();

                spriteAnim.Play(clip, 1f);
                spriteAnim.m_animator.Play("a", 0, progress % 1);
                spriteAnim.m_animator.Update(0f);
            }

            playerControl.cosmetics.colorBlindText.color = Color.white;
            if (PlayerControl.LocalPlayer.Data.IsImpostor() && playerControl.Data.IsImpostor()) playerControl.nameText().color = Patches.Colors.Impostor;
        }


        public static CustomPlayerOutfitType GetCustomOutfitType(this PlayerControl playerControl)
        {
            return (CustomPlayerOutfitType)playerControl.CurrentOutfitType;
        }

        public static bool IsNullOrDestroyed(this System.Object obj)
        {

            if (object.ReferenceEquals(obj, null)) return true;

            if (obj is UnityEngine.Object) return (obj as UnityEngine.Object) == null;

            return false;
        }
        public static Texture2D CreateEmptyTexture(int width = 0, int height = 0)
        {
            return new Texture2D(width, height, TextureFormat.RGBA32, Texture.GenerateAllMips, false, IntPtr.Zero);
        }

        public static TMPro.TextMeshPro nameText(this PlayerControl p) => p?.cosmetics?.nameText;

        public static TMPro.TextMeshPro NameText(this PoolablePlayer p) => p.cosmetics.nameText;

        public static UnityEngine.SpriteRenderer myRend(this PlayerControl p) => p.cosmetics.currentBodySprite.BodySprite;
    }
}