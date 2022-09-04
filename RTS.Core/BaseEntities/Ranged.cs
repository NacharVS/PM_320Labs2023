namespace RTS.Core.BaseEntities;

public abstract class Ranged : Military
{
    public int AttackRange { get; private protected set; }
    public int Mana { get; private protected set; }

    protected Ranged(int health, int cost, string? name, int level, int speed, int damage, 
        int attackSpeed, int armor, int attackRange, int mana) 
        : base(health, cost, name, level, speed, damage, attackSpeed, armor)
    {
        AttackRange = attackRange;
        Mana = mana;
    }
}