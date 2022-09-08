namespace Warcraft.Core.EventArgs;

public class HitArgs
{
    public int HitValue { get; set; }
    public int PreviousHealth { get; set; }
    public int CurrentHealth { get; set; }

    public HitArgs(int hitValue, int unitHealth)
    {
        HitValue = hitValue;
        PreviousHealth = unitHealth;
        CurrentHealth = unitHealth - hitValue;
    }
}