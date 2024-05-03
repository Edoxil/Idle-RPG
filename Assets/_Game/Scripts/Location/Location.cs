using Sirenix.OdinInspector;
using UnityEngine;

namespace IdleRPG
{
    public class Location : MonoBehaviour
    {
        [field: SerializeField, Required] public LocationType LocationType { get; private set; }
        [field: SerializeField, Required] public Transform PlayerSpawnPoint { get; private set; }
        [field: SerializeField, Required] public Transform EnemySpawnPoint { get; private set; }


        private void Start()
        {
            // 1. Ќужен список врагов на локации и шанс их по€влени€
        }
    }
}