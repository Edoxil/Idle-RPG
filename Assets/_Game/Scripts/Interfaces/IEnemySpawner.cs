using System;

namespace IdleRPG
{
    public interface IEnemySpawner
    {
        public event Action<Enemy> EnemySpawned;
        public Enemy CurrentEnemy { get; }
    }
}