using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IdleRPG
{
    public class Enemy : MonoBehaviour,ICombatant
    {
        [SerializeField,Required] private EnemyAnimations _animations;
        [SerializeField,Required] private Stats _stats;

        public void Attak()
        {
            _animations.Attack();
        }

        public Stats GetStats()
        {
            return _stats;
        }

        public void ReceiveDamage(int amount)
        {
            Debug.Log($"{name} receive {amount} damage");
        }
    }
}