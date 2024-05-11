using TriInspector;
using UnityEngine;
using UnityEngine.UI;

namespace IdleRPG
{
    public sealed class Combat : MonoBehaviour
    {
        private ICombatant _player;
        private ICombatant _enemy;

        private DelayedAction _playerAttackAction;
        private DelayedAction _enemyAttackAction;

        public void Initialize(ICombatant player, ICombatant enemy)
        {
            _player = player;
            _enemy = enemy;
        }

        [Button]
        public void StatBattle()
        {
            _playerAttackAction = new DelayedAction(_player.GetCombatStats().AttackDelay, _player.Attak);
            _enemyAttackAction = new DelayedAction(_enemy.GetCombatStats().AttackDelay, _enemy.Attak);

            _playerAttackAction.Begin();
            _enemyAttackAction.Begin();
        }
    }
}