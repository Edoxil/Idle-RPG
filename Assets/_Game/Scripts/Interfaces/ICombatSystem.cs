using System;

public interface ICombatSystem
{
    public event Action CombatStarted;
    public event Action CombatComplited;
    public event Action CombatInterrupted;

    public bool InProcess { get; }
}
