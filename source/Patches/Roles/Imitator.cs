using System.Collections.Generic;
using TownOfUs.Extensions;
using UnityEngine;

namespace TownOfUs.Roles
{
    public class Imitator : Role
    {
        public readonly List<GameObject> Buttons = new List<GameObject>();

        public readonly List<bool> ListOfActives = new List<bool>();
        public PlayerControl ImitatePlayer = null;

        public List<RoleEnum> trappedPlayers = null;
        public PlayerControl confessingPlayer = null;


        public Imitator(PlayerControl player) : base(player)
        {
            Name = "Imitator";
            ImpostorText = () => Language.GetString("roles.imitator");
            TaskText = () => Language.GetString("roles.imitator");
            Color = Patches.Colors.Imitator;
            RoleType = RoleEnum.Imitator;
            AddToRoleHistory(RoleType);
        }
    }
}