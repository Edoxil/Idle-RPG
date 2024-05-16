using System;
using TriInspector;
using Zenject;

namespace IdleRPG
{
    public class EnemySpawnSystem : IInitializable, IDisposable, IEnemySpawnSystem
    {
        private ILocationSwitchSystem _locationSwitcher;
        private IFactory<Enemy, EnemyType> _factory;
        private IEnemySearchSystem _enemySearcher;

        public Enemy CurrentEnemy { get; private set; }

        public event Action<Enemy> EnemySpawned;

        [Inject]
        public EnemySpawnSystem(ILocationSwitchSystem locationSwitcher,
            IFactory<Enemy, EnemyType> factory,
            IEnemySearchSystem enemySearcher)
        {
            _locationSwitcher = locationSwitcher;
            _factory = factory;
            _enemySearcher = enemySearcher;
        }

        public void Initialize()
        {
            _enemySearcher.SearchCompleted += SpawnRandomEnemy;
        }

        public void Dispose()
        {
            _enemySearcher.SearchCompleted -= SpawnRandomEnemy;
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