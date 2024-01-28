using HarmonyLib;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using TownOfUs.Extensions;

namespace TownOfUs.RainbowMod
{
    [HarmonyPatch(typeof(TranslationController), nameof(TranslationController.GetString),
        new[] { typeof(StringNames), typeof(Il2CppReferenceArray<Il2CppSystem.Object>) })]
    public class PatchColours
    {
        public static bool Prefix(ref string __result, [HarmonyArgument(0)] StringNames name)
        {
            var newResult = (int)name switch
            {
                999983 => Language.GetString("cosmetics.colors.watermelon"),
                999984 => Language.GetString("cosmetics.colors.chocolate"),
                999985 => Language.GetString("cosmetics.colors.skyblue"),
                999986 => Language.GetString("cosmetics.colors.beige"),
                999987 => Language.GetString("cosmetics.colors.magenta"),
                999988 => Language.GetString("cosmetics.colors.turquoise"),
                999989 => Language.GetString("cosmetics.colors.lilac"),
                999990 => Language.GetString("cosmetics.colors.olive"),
                999991 => Language.GetString("cosmetics.colors.azure"),
                999992 => Language.GetString("cosmetics.colors.plum"),
                999993 => Language.GetString("cosmetics.colors.jungle"),
                999994 => Language.GetString("cosmetics.colors.mint"),
                999995 => Language.GetString("cosmetics.colors.chartreuse"),
                999996 => Language.GetString("cosmetics.colors.macau"),
                999997 => Language.GetString("cosmetics.colors.tawny"),
                999998 => Language.GetString("cosmetics.colors.gold"),
                999999 => Language.GetString("cosmetics.colors.rainbow"),
                _ => null
            };
            if (newResult != null)
            {
                __result = newResult;
                return false;
            }

            return true;
        }
    }
}
