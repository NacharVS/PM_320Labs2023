namespace Warcraft.Core;

public abstract class Ranged : Military
{
    public int AttackRange { get; protected set; }
    public int Mana { get; protected set; }

    protected Ranged(int health, int cost, string name, int level, int speed,
        int attackSpeed, int attackRange) : base(health, cost, name, level,
        speed, attackSpeed)
    {
        AttackRange = attackRange;
    }
}