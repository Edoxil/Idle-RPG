using TriInspector;
using UnityEngine;
using Zenject;

namespace IdleRPG
{
    public sealed class Player : MonoBehaviour, ICombatant, IInitializable
    {
        [SerializeField, Required] private PlayerAnimations _animations;
        [SerializeField, Required] private BaseStats _baseStats;
        private CombatStats _combatStats;

        public void Initialize()
        {
            CreateCombatStats();
        }

        public void ResetAnimations()
        {

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