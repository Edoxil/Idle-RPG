using System;
using TriInspector;
using Zenject;

namespace IdleRPG
{
    public class EnemySpawnSystem : IInitializable, IDisposable, IEnemySpawner
    {
        private ILocationSwitcher _locationSwitcher;
        private IFactory<Enemy, EnemyType> _factory;
        private IEnemySearcher _enemySearcher;

        public Enemy CurrentEnemy { get; private set; }

        public event Action<Enemy> EnemySpawned;

        [Inject]
        public EnemySpawnSystem(ILocationSwitcher locationSwitcher,
            IFactory<Enemy, EnemyType> factory,
            IEnemySearcher enemySearcher)
        {
            _locationSwitcher = locationSwitcher;
            _factory = factory;
            _enemySearcher = enemySearcher;
        }

        public void Initialize()
        {
            _enemySearcher.SearchComplete += SpawnRandomEnemy;
        }

        public void Dispose()
        {
            _enemySearcher.SearchComplete -= SpawnRandomEnemy;
        }

        [Button]
        private void SpawnRandomEnemy()
        {
            Randomizer<RandomEnemy> randomizer = new Randomizer<RandomEnemy>();

            RandomEnemy enemy = randomizer.GetRandomValue(_locationSwitcher.CurrentLocation.Enemies);
            CurrentEnemy = _factory.Create(enemy.EnemyType, _locationSwitcher.CurrentLocation.EnemySpawnPoint);
            EnemySpawned?.Invoke(CurrentEnemy);
        }

    }
}