using System.Collections.Generic;
using TriInspector;
using UnityEngine;

namespace IdleRPG
{
    public sealed class Location : MonoBehaviour
    {
        [field: SerializeField] public LocationType LocationType { get; private set; }
        [field: SerializeField, Required] public Transform PlayerSpawnPoint { get; private set; }
        [field: SerializeField, Required] public Transform EnemySpawnPoint { get; private set; }
        [field: SerializeField, Required] public Sprite Icon { get; private set; }
        [field: SerializeField] public List<RandomEnemy> Enemies { get; private set; }
    }
}