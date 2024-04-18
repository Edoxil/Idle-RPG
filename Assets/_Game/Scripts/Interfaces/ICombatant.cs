namespace IdleRPG
{
    public interface ICombatant
    {
        public void Attak();
        public void ReceiveDamage(int amount);
        public Stats GetStats();
    }
}