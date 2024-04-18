using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace IdleRPG
{

    [CreateAssetMenu(fileName = "Stats", menuName = "Stats/Stats", order = 1)]
    public class Stats : ScriptableObject
    {
        [field: SerializeField, OnValueChanged(nameof(NotifyStatsChanged))] public int HealthPoints { get; private set; }
        [field: SerializeField, OnValueChanged(nameof(NotifyStatsChanged))] public int AttackPower { get; private set; }
        [field: SerializeField, OnValueChanged(nameof(NotifyStatsChanged))] public int Defense { get; private set; }
        [field: SerializeField, OnValueChanged(nameof(NotifyStatsChanged))] public float AttackDelay { get; private set; }


        public event Action StatsChanged;

        private void NotifyStatsChanged()
        {
            StatsChanged?.Invoke();
        }

        public static Stats Clone(Stats original)
        {
            Stats clone = CreateInstance<Stats>();

            clone.HealthPoints = original.HealthPoints;
            clone.AttackPower = original.AttackPower;
            clone.Defense = original.Defense;
            clone.AttackDelay = original.AttackDelay;

            return clone;
        }

    }
}