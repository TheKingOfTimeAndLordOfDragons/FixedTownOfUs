using HarmonyLib;
using TownOfUs.Extensions;

namespace TownOfUs.Patches
{
    [HarmonyPatch(typeof(EmergencyMinigame), nameof(EmergencyMinigame.Update))]
    class EmergencyMinigameUpdatePatch {
        static void Postfix(EmergencyMinigame __instance) {
            var roleCanCallEmergency = true;
            var statusText = "";

            // Deactivate emergency button for Swapper
            if (PlayerControl.LocalPlayer.Is(RoleEnum.Swapper) && !CustomGameOptions.SwapperButton) {
                roleCanCallEmergency = false;
                statusText = Language.GetString("nobutton.swapper");
            }

            // Potentially deactivate emergency button for Jester
            if (PlayerControl.LocalPlayer.Is(RoleEnum.Jester) && !CustomGameOptions.JesterButton) {
                roleCanCallEmergency = false;
                statusText = Language.GetString("nobutton.jester");
            }

            // Potentially deactivate emergency button for Executioner
            if (PlayerControl.LocalPlayer.Is(RoleEnum.Executioner) && !CustomGameOptions.ExecutionerButton) {
                roleCanCallEmergency = false;
                statusText = Language.GetString("nobutton.executioner");
            }

            if (!roleCanCallEmergency) {
                __instance.StatusText.text = statusText;
                __instance.NumberText.text = string.Empty;
                __instance.ClosedLid.gameObject.SetActive(true);
                __instance.OpenLid.gameObject.SetActive(false);
                __instance.ButtonActive = false;
                return;
            }
        }
    }
}