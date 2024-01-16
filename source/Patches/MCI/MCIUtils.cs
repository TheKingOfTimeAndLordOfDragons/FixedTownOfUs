using InnerNet;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using HarmonyLib;
using TownOfUs.Patches;

namespace TownOfUs.MCI
{
    public static class MCIUtils
    {
        public static readonly Dictionary<int, ClientData> Clients = new();
        public static readonly Dictionary<byte, int> PlayerClientIDs = new();
        public static readonly Dictionary<byte, Vector3> SavedPositions = new();

        public static int AvailableId()
        {
            for (var i = 1; i < 128; i++)
            {
                if (!Clients.ContainsKey(i) && PlayerControl.LocalPlayer.OwnerId != i)
                    return i;
            }

            return -1;
        }

        public static void CleanUpLoad()
        {
            if (GameData.Instance.AllPlayers.Count == 1)
            {
                Clients.Clear();
                PlayerClientIDs.Clear();
                SavedPositions.Clear();
            }
        }

        public static void CreatePlayerInstances(int count)
        {
            for (var i = 0; i < count; i++)
                CreatePlayerInstance();
        }

        public static void CreatePlayerInstance()
        {
            var sampleId = AvailableId();
            var sampleC = new ClientData(sampleId, $"Bot-{sampleId}", new()
            {
                Platform = Platforms.StandaloneWin10,
                PlatformName = "Bot"
            }, 1, "", "robotmodeactivate");

            AmongUsClient.Instance.CreatePlayer(sampleC);
            AmongUsClient.Instance.allClients.Add(sampleC);

            sampleC.Character.SetName($"Bot {sampleC.Character.PlayerId}");
            sampleC.Character.SetSkin(HatManager.Instance.allSkins[Random.RandomRangeInt(0, HatManager.Instance.allSkins.Count)].ProdId, 0);
            sampleC.Character.SetNamePlate(HatManager.Instance.allNamePlates[Random.RandomRangeInt(0, HatManager.Instance.allNamePlates.Count)].ProdId);
            sampleC.Character.SetPet(HatManager.Instance.allPets[Random.RandomRangeInt(0, HatManager.Instance.allPets.Count)].ProdId);
            sampleC.Character.SetHat("hat_NoHat", 0);
            sampleC.Character.SetColor(Random.RandomRangeInt(0, Palette.PlayerColors.Length));
            sampleC.Character.MyPhysics.ResetMoveState();

            Clients.Add(sampleId, sampleC);
            PlayerClientIDs.Add(sampleC.Character.PlayerId, sampleId);
            SavedPositions.Remove(sampleC.Character.PlayerId);
        }

        public static void RemovePlayer(byte id)
        {
            if (id == 0)
                return;

            var clientId = Clients.FirstOrDefault(x => x.Value.Character.PlayerId == id).Key;
            Clients.Remove(clientId, out var outputData);
            PlayerClientIDs.Remove(id);
            SavedPositions.Remove(id);
            AmongUsClient.Instance.RemovePlayer(clientId, DisconnectReasons.Custom);
            AmongUsClient.Instance.allClients.Remove(outputData);
        }

        public static void RemoveAllPlayers()
        {
            foreach (var playerId in PlayerClientIDs.Keys)
                RemovePlayer(playerId);
            SwitchTo(0);
        }

        public static void SwitchTo(byte playerId)
        {
            if (!TownOfUs.MCIActive)
                return;

            SavedPositions[PlayerControl.LocalPlayer.PlayerId] = PlayerControl.LocalPlayer.transform.position;


            PlayerControl.LocalPlayer.NetTransform.RpcSnapTo(PlayerControl.LocalPlayer.transform.position);
            PlayerControl.LocalPlayer.moveable = false;

            var light = PlayerControl.LocalPlayer.lightSource;
            var savedId = PlayerControl.LocalPlayer.PlayerId;

            //Setup new player
            var newPlayer = Utils.PlayerById(playerId);

            if (newPlayer == null)
                return;

            PlayerControl.LocalPlayer = newPlayer;
            PlayerControl.LocalPlayer.lightSource = light;
            PlayerControl.LocalPlayer.moveable = true;

            AmongUsClient.Instance.ClientId = PlayerControl.LocalPlayer.OwnerId;
            AmongUsClient.Instance.HostId = PlayerControl.LocalPlayer.OwnerId;

            HudManager.Instance.SetHudActive(true);
            HudManager.Instance.ShadowQuad.gameObject.SetActive(!PlayerControl.LocalPlayer.Data.IsDead);

            light.transform.SetParent(PlayerControl.LocalPlayer.transform);
            light.transform.localPosition = PlayerControl.LocalPlayer.Collider.offset;

            Camera.main.GetComponent<FollowerCamera>().SetTarget(PlayerControl.LocalPlayer);
            PlayerControl.LocalPlayer.MyPhysics.ResetMoveState(true);
            KillAnimation.SetMovement(PlayerControl.LocalPlayer, true);
            PlayerControl.LocalPlayer.MyPhysics.inputHandler.enabled = true;

            if (SavedPositions.TryGetValue(playerId, out var pos))
                PlayerControl.LocalPlayer.NetTransform.RpcSnapTo(pos);

            if (SavedPositions.TryGetValue(savedId, out var pos2))
                Utils.PlayerById(savedId).NetTransform.RpcSnapTo(pos2);
        }

        public static void SetForegroundForAlive(this MeetingHud __instance)
        {
            __instance.amDead = false;
            __instance.SkipVoteButton.gameObject.SetActive(true);
            __instance.SkipVoteButton.AmDead = false;
            __instance.Glass.gameObject.SetActive(false);
        }
    }
}