using System;
using TriInspector;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace IdleRPG
{
    public sealed class CombatSystem: ICombatSystem,IInitializable,IDisposable
    {
        private DelayedAction _playerAttackAction;
        private DelayedAction _enemyAttackAction;

        public event Action CombatStarted;
        public event Action CombatComplited;
        public event Action CombatInterrupted;

        public bool InProcess { get; private set; }

        public void Initialize()
        {
        }

        public void Dispose()
        {
        }

    }
}