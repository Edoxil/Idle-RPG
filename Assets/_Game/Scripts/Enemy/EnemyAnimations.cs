using TriInspector;
using UnityEngine;

namespace IdleRPG
{
    public sealed class EnemyAnimations : MonoBehaviour
    {
        [SerializeField, ReadOnly] private Animator _animator;

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