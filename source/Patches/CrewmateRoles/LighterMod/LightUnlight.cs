using HarmonyLib;
using TownOfUs.Roles;

namespace TownOfUs.CrewmateRoles.LighterMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    [HarmonyPriority(Priority.Last)]
    public class LightUnlight
    {
        [HarmonyPriority(Priority.Last)]
        public static void Postfix(HudManager __instance)
        {
            foreach (var role in Role.GetRoles(RoleEnum.Lighter))
            {
                var lighter = (Lighter) role;
                if (lighter.IsUsingLight)
                    lighter.Light();
                else if (lighter.Enabled) lighter.UnLight();
            }
        }
    }
}