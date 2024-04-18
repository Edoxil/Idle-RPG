using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IdleRPG
{
    public class Combat : MonoBehaviour
    {
        [SerializeField] private Player PLAYER;
        [SerializeField] private Enemy ENEMY;


        private ICombatant _player;
        private ICombatant _enemy;

        private void Start()
        {
            Initialize(PLAYER, ENEMY);
        }

        public void Initialize(ICombatant player, ICombatant enemy)
        {
            _player = player;
            _enemy = enemy;
        }


        public void StatBattle()
        {

        }

    }
}