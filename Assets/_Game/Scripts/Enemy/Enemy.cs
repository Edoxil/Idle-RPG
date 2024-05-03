using Sirenix.OdinInspector;
using UnityEngine;

namespace IdleRPG
{
    public class Enemy : MonoBehaviour, ICombatant
    {
        [field: SerializeField] public EnemyType EnemyType { get; private set; }
        [SerializeField, Required] private EnemyAnimations _animations;
        [SerializeField, Required] private BaseStats _baseStats;

        private CombatStats _combatStats;

        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            CreateCombatStats();
        }

        public void Attak()
        {
            _animations.Attack();
        }

        public CombatStats GetCombatStats()
        {
            return _combatStats;
        }

        private void CreateCombatStats()
        {
            CombatStatsBuilder builder = new CombatStatsBuilder();
            _combatStats = builder.AddBaseStats(_baseStats)
                .Build();
        }
    }
}