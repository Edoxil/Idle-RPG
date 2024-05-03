using Sirenix.OdinInspector;
using UnityEngine;

namespace IdleRPG
{
    [CreateAssetMenu(fileName = "BaseStats", menuName = "Stats/BaseStats", order = 1)]
    public class BaseStats : ScriptableObject
    {
        [field: SerializeField, OnValueChanged(nameof(CreateDemoCombatStats))] public int Strenght { get; private set; }
        [field: SerializeField, OnValueChanged(nameof(CreateDemoCombatStats))] public int Agility { get; private set; }
        [field: SerializeField, OnValueChanged(nameof(CreateDemoCombatStats))] public int Durability { get; private set; }
        [field: SerializeField, OnValueChanged(nameof(CreateDemoCombatStats))] public int LifeForce { get; private set; }
        [field: SerializeField, OnValueChanged(nameof(CreateDemoCombatStats))] public float AttackDelay { get; private set; }

        [ShowInInspector, ReadOnly] private CombatStats _demoCombatStats;

        private void OnValidate()
        {
            CreateDemoCombatStats();
        }

        private void CreateDemoCombatStats()
        {
            CombatStatsBuilder builder = new CombatStatsBuilder();

            _demoCombatStats = builder.AddBaseStats(this)
                                      .Build();
        }

    }
}