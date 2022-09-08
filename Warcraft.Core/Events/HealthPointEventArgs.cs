namespace Warcraft.Core.Events;

public class HealthPointEventArgs : EventArgs
{
    public int PreviousHealth { get; }
    public int CurrentHealth { get; }
    
    public HealthPointEventArgs(int previousHp, int currentHp)
    {
        PreviousHealth = previousHp;
        CurrentHealth = currentHp;
    }
}