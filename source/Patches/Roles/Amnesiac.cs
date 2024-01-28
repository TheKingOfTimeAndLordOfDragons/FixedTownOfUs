using System.Collections.Generic;
using System.Linq;
using TownOfUs.Extensions;
using Object = UnityEngine.Object;

namespace TownOfUs.Roles
{
    public class Amnesiac : Role
    {
        public Dictionary<byte, ArrowBehaviour> BodyArrows = new Dictionary<byte, ArrowBehaviour>();
        public bool SpawnedAs = true;

        public Amnesiac(PlayerControl player) : base(player)
        {
            Name = "Amnesiac";
            ImpostorText = () => Language.GetString("roles.amnesiac");
            TaskText = () => SpawnedAs ? Language.GetString("roles.amnesiac") : Language.GetString("roles.amnesiac.not");
            Color = Patches.Colors.Amnesiac;
            RoleType = RoleEnum.Amnesiac;
            AddToRoleHistory(RoleType);
            Faction = Faction.NeutralBenign;
        }

        public DeadBody CurrentTarget;

        public void DestroyArrow(byte targetPlayerId)
        {
            var arrow = BodyArrows.FirstOrDefault(x => x.Key == targetPlayerId);
            if (arrow.Value != null)
                Object.Destroy(arrow.Value);
            if (arrow.Value.gameObject != null)
                Object.Destroy(arrow.Value.gameObject);
            BodyArrows.Remove(arrow.Key);
        }
    }
}