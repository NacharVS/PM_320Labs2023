namespace Warcraft.Core;

public class Footman : Military
{
    private const int BerserkBoundary = 10;
    public Footman(int health, int cost, string name, int level, int speed, int attackSpeed)
        : base(health, cost, name, level, speed, attackSpeed)
    {
        OnHpChange += CheckBerserkMode;
    }

    // Berserk passive
    private void CheckBerserkMode(object? sender, EventArgs args)
    {
        if (MaxHealth - Health < BerserkBoundary)
            Damage *= 2;
        else if (args is HealthPointEventArgs
                 {
                     PreviousHealth: < BerserkBoundary,
                     CurrentHealth: >= BerserkBoundary
                 })
            Damage /= 2;
    }

    public void Stun(Unit target)
    {
        if (target is Movable movableTarget)
        {
            movableTarget.Slow(100);
        }
    }

    public override void Move()
    {
    }
}