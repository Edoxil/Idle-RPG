using UnityEngine;
using Zenject;

namespace IdleRPG
{
    public class EnemiesFactory : IFactory<Enemy, EnemyType>
    {
        private EnemiesDataProvider _dataProvider;

        [Inject]
        public EnemiesFactory(EnemiesDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public Enemy Create(EnemyType key, Transform parent)
        {
            Enemy enemy = _dataProvider.GetPrefab(key);
            return GameObject.Instantiate(enemy, parent);
        }
    }
}