using Sirenix.OdinInspector;
using UnityEngine;

namespace IdleRPG
{
    public class Player : MonoBehaviour, ICombatant
    {
        [SerializeField, Required] private PlayerAnimations _animations;
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