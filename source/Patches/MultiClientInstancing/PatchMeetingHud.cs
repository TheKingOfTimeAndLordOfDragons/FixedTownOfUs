using HarmonyLib;

namespace TownOfUs.MultiClientInstancing
{
    [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.Confirm))]
    public sealed class SameVoteAll
    {
        public static void Postfix(MeetingHud __instance, ref byte suspectStateIdx)
        {
            if (!ConstantVariables.IsLocalGame)
                return;

            if (!TownOfUs.MCIActive)
                return;

            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
                __instance.CmdCastVote(player.PlayerId, suspectStateIdx);
        }
    }
}