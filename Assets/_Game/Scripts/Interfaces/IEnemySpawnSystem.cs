using System;

namespace IdleRPG
{
    public interface IEnemySpawnSystem
    {
        public event Action<Enemy> EnemySpawned;
        public Enemy CurrentEnemy { get; }
    }
}