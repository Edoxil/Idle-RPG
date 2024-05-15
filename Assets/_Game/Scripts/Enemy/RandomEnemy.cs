using UnityEngine;

namespace IdleRPG
{
    [System.Serializable]
    public class RandomEnemy : IRandomValue
    {
        [field: SerializeField] public EnemyType EnemyType { get; private set; }
        [field: SerializeField, Range(0, 1f)] public float Chance { get; private set; }
    }
}