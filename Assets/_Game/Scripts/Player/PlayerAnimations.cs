using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IdleRPG
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimations : MonoBehaviour
    {
        [SerializeField,ReadOnly]private Animator _animator;

        [Button]
        public void Attack()
        {
            _animator.SetTrigger(AnimationHashContainer.Attack);
        }

        private void OnValidate()
        {
            _animator = GetComponent<Animator>();
        }
    }
}