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

        private static PlayerController _playerController;

        public static void SetPlayer()
        {
            Player = GameObject.FindGameObjectWithTag(Enum.GetName(typeof(Tags), Tags.Player));
            _playerController = Player.GetComponent<PlayerController>();
        }

        public static void DamagePlayer(int damage)
        {
            if (_playerController == null) return;

            _playerController.SetHealth(_playerController.Health - damage);
        }
    }
}
