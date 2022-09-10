
using System;
using System.Threading;

public abstract class Range : Military
{
    public int AttackRange { get; private protected set; }
    public int Mana { get; private protected set; }

    protected Range(int health, int cost, string? name, int level, int speed, int damage, 
        int attackSpeed, int armor, int attackRange, int mana) 
        : base(health, cost, name, level, speed, damage, attackSpeed, armor)
    {
        AttackRange = attackRange;
        Mana = mana;
    }

    public override void Attack(Unit entity)
    {
        if (entity.IsDestroyed)
        {
            Console.WriteLine("игрок помер");
        }
        Thread.Sleep(AttackSpeed);
        entity.Health -= Damage > ((Range)entity).Armor? Damage : 0;
    }
}