using Assets.Code.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.Managers
{
    public static class PlayerManager
    {
        public static GameObject Player;

        public static void SetPlayer()
        {
            Player = GameObject.FindGameObjectWithTag(Enum.GetName(typeof(Tags), Tags.Player));
        }
    }
}
