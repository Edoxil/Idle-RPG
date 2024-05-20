using System;
using UnityEngine;
using Zenject;

namespace IdleRPG
{
    public sealed class CombatSystem : ICombatSystem, IInitializable, IDisposable
    {
        private DelayedAction _playerAttackAction;
        private DelayedAction _enemyAttackAction;

        private IEnemySpawnSystem _spawnSystem;

        public event Action CombatStarted;
        public event Action CombatComplited;
        public event Action CombatInterrupted;

        public bool InProcess { get; private set; }

        [Inject]
        public CombatSystem(IEnemySpawnSystem spawnSystem)
        {
            _spawnSystem = spawnSystem;
        }

        public void Initialize()
        {
            _spawnSystem.EnemySpawned += OnEnemySpawned;
        }

        public void Dispose()
        {
            _spawnSystem.EnemySpawned -= OnEnemySpawned;
        }

        private void OnEnemySpawned(Enemy enemy)
        {
            Debug.Log("Enemy spawned");
        }

    }
}