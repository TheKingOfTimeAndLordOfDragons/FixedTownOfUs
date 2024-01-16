using HarmonyLib;
using TMPro;
using TownOfUs.CustomOption;
using UnityEngine;

namespace TownOfUs.Patches
{
    [HarmonyPatch]
    public static class CredentialsPatch {
        public static string fullCredentialsVersion =
$@"<size=130%><color=#00FF00FF>Fixed Town Of Us</color></size> v{TownOfUs.Version.ToString()}";
        public static string fullCredentials =
$@"<size=60%>Remodded by <color=#00FF00FF>NesTT17</color> & <color=#00FF00FF>KTLD</color>
Modded by <color=#00FF00FF>Donners</color> & <color=#00FF00FF>MyDragonBreath</color></size>";
        public static string mainMenuCredentials =
$@"Remodded by <color=#00FF00FF>NesTT17</color> & <color=#00FF00FF>KTLD</color>
Modded by <color=#00FF00FF>Donners</color> & <color=#00FF00FF>MyDragonBreath</color>";
        public static string contributorsCredentials =
$@"<size=60%> <color=#00FF00FF>Formerly: Slushiegoose & Polus.gg</color></size>";

        [HarmonyPatch(typeof(PingTracker), nameof(PingTracker.Update))]
        internal static class PingTrackerPatch
        {
            static void Postfix(PingTracker __instance) {
                __instance.text.alignment = TMPro.TextAlignmentOptions.TopRight;
                if (AmongUsClient.Instance.GameState == InnerNet.InnerNetClient.GameStates.Started) {
                    string gameModeText = $"";
                    if (Generate.CurrentGameMode == GameMode.Classic) gameModeText = "Classic";
                    else if (Generate.CurrentGameMode == GameMode.AllAny) gameModeText = "All Any";
                    else if (Generate.CurrentGameMode == GameMode.KillingOnly) gameModeText = "Killing Only";
                    else if (Generate.CurrentGameMode == GameMode.Cultist) gameModeText = "Cultist";
                    if (gameModeText != "") gameModeText = CustomOption.CustomOption.cs(Color.yellow, gameModeText) + "\n";
                    __instance.text.text = $"<size=130%><color=#00FF00FF>Fixed Town Of Us</color></size> v{TownOfUs.Version.ToString()}\n{gameModeText}" + __instance.text.text;
                    if (PlayerControl.LocalPlayer.Data.IsDead || (!(PlayerControl.LocalPlayer == null) && PlayerControl.LocalPlayer.Is(ModifierEnum.Lover))) {
                        __instance.transform.localPosition = new Vector3(3.45f, __instance.transform.localPosition.y, __instance.transform.localPosition.z);
                    } else {
                        __instance.transform.localPosition = new Vector3(4.2f, __instance.transform.localPosition.y, __instance.transform.localPosition.z);
                    }
                } else {
                    string gameModeText = $"";
                    if (Generate.CurrentGameMode == GameMode.Classic) gameModeText = "Classic";
                    else if (Generate.CurrentGameMode == GameMode.AllAny) gameModeText = "All Any";
                    else if (Generate.CurrentGameMode == GameMode.KillingOnly) gameModeText = "Killing Only";
                    else if (Generate.CurrentGameMode == GameMode.Cultist) gameModeText = "Cultist";
                    if (gameModeText != "") gameModeText = CustomOption.CustomOption.cs(Color.yellow, gameModeText) + "\n";

                    __instance.text.text = $"{fullCredentialsVersion}\n  {gameModeText + fullCredentials}\n {__instance.text.text}";
                    __instance.transform.localPosition = new Vector3(3.5f, __instance.transform.localPosition.y, __instance.transform.localPosition.z);
                }
            }
        }

        [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start))]
        public static class LogoPatch {
            public static SpriteRenderer renderer;
            public static Sprite bannerSprite;
            private static PingTracker instance;

            static void Postfix(PingTracker __instance) {
                var touLogo = new GameObject("bannerLogo_TOU");
                touLogo.transform.SetParent(GameObject.Find("RightPanel").transform, false);
                touLogo.transform.localPosition = new Vector3(-0.4f, 1f, 5f);

                renderer = touLogo.AddComponent<SpriteRenderer>();
                loadSprites();
                renderer.sprite = TownOfUs.ToUBanner;

                instance = __instance;
                loadSprites();
                renderer.sprite = bannerSprite;

                var credentialObject = new GameObject("credentialsTOR");
                var credentials = credentialObject.AddComponent<TextMeshPro>();
                credentials.SetText($"v{TownOfUs.Version.ToString()}\n<size=30f%>\n</size>{mainMenuCredentials}\n<size=30%>\n</size>{contributorsCredentials}");
                credentials.alignment = TMPro.TextAlignmentOptions.Center;
                credentials.fontSize *= 0.05f;
                credentials.transform.SetParent(touLogo.transform);
                credentials.transform.localPosition = Vector3.down * 1.25f;
            }

            public static void loadSprites() {
                if (bannerSprite == null) bannerSprite = TownOfUs.ToUBanner;
            }
        }
    }
}