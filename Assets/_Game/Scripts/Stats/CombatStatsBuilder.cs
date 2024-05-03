namespace IdleRPG
{
    public class CombatStatsBuilder
    {
        private CombatStats _combatStats;

        public CombatStatsBuilder()
        {
            _combatStats = new CombatStats();
        }

        public CombatStatsBuilder AddBaseStats(BaseStats baseStats)
        {
            _combatStats.MaxHealthPoints += baseStats.LifeForce * StatsConfig.MAX_HEALTHPOINTS_PER_LIFEFORCE;
            _combatStats.AttackPower += baseStats.Strenght * StatsConfig.ATTACK_POWER_PER_STRENGTH;
            _combatStats.Defense += baseStats.Durability * StatsConfig.DEFENSE_PER_DURABILITY;

            _combatStats.AttackDelay = baseStats.AttackDelay - baseStats.Agility * StatsConfig.ATTACK_DELAY_REDUCE_PER_AGILITY;

            if (_combatStats.AttackDelay < StatsConfig.MIN_ATTACK_DELAY)
                _combatStats.AttackDelay = StatsConfig.MIN_ATTACK_DELAY;

            return this;
        }

        public CombatStats Build()
        {
            return _combatStats;
        }
    }
}