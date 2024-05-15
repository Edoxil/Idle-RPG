using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace IdleRPG
{
    [CreateAssetMenu(fileName = "EnemiesDataProvider", menuName = "Providers/EnemiesDataProvider", order = 1)]
    public class EnemiesDataProvider : ScriptableObject
    {
        [SerializeField] private List<Enemy> _allEnemies;

        public Enemy GetPrefab(EnemyType enemyType)
        {
            return _allEnemies.First(enemy => enemy.EnemyType == enemyType);
        }
    }
}