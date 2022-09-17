namespace Warcraft.Core.BaseClasses;

public abstract class Ranged : Military
{
    public int AttackRange { get; protected set; }

    protected Ranged(IEventLogger logger, int health, int cost, string name, int level, int speed,
        int attackSpeed, int damage, int attackRange, int mana) : base(logger, health, cost, name, level,
        speed, attackSpeed, damage)
    {
        AttackRange = attackRange;
        Mana = mana;
    }
}