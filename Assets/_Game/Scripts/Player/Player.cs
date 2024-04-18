using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IdleRPG
{
    public class Player : MonoBehaviour,ICombatant
    {
        [SerializeField,Required] private PlayerAnimations _animations;
        [SerializeField,Required] private Stats _baseStats;

        public void Attak()
        {
            _animations.Attack();
        }

        public Stats GetStats()
        {
            return _baseStats;
        }

        public void ReceiveDamage(int amount)
        {
            Debug.Log($"{name} receive {amount} damage");
        }
    }
}