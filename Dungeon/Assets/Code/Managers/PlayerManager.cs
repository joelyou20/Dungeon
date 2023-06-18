using Assets.Code.Enums;
using Assets.Code.Stats;
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
        private static GameObject _player;

        public static GameObject Player 
        { 
            get {
                GameObject value = _player == null ? GameObject.FindGameObjectWithTag(Enum.GetName(typeof(Tags), Tags.Player)) : _player;
                _player = value;
                return value;
            }
            set => _player = value; 
        }

        public static bool IsDead => PlayerStats.Health <= 0;

        public static void DamagePlayer(int damage)
        {
            var health = PlayerStats.Health - damage;
            Player.GetComponent<PlayerController>().SetHealth(health.Value);
            PlayerStats.Health = health;
        }

        public static void InitializePlayer(int health, float speed, int attackSpeed)
        {
            PlayerStats.Health = health;
            PlayerStats.MaxHealth = health;
            PlayerStats.Speed = speed;
            PlayerStats.AttackSpeed = attackSpeed;
        }
    }
}
