using UnityEngine;

namespace IdleRPG
{
    [System.Serializable]
    public class CombatStats
    {
        [field: SerializeField] public int MaxHealthPoints { get; set; }
        [field: SerializeField] public int CurrentHealthPoints { get; set; }
        [field: SerializeField] public int AttackPower { get; set; }
        [field: SerializeField] public int Defense { get; set; }
        [field: SerializeField] public float AttackDelay { get; set; }

        public CombatStats()
        {

        }
    }
}