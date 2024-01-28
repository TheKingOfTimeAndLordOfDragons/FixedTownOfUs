using System.Collections.Generic;
using TownOfUs.Extensions;
using UnityEngine;

namespace TownOfUs.Roles
{
    public class Swapper : Role
    {
        public readonly List<GameObject> Buttons = new List<GameObject>();

        public readonly List<bool> ListOfActives = new List<bool>();


        public Swapper(PlayerControl player) : base(player)
        {
            Name = "Swapper";
            ImpostorText = () => Language.GetString("roles.swapper");
            TaskText = () => Language.GetString("roles.swapper");
            Color = Patches.Colors.Swapper;
            RoleType = RoleEnum.Swapper;
            AddToRoleHistory(RoleType);
        }
    }
}