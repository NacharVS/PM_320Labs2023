
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

    public void Attack(Unit entity)
    {
        if (entity.IsDestroyed)
        {
            new Exception();
        }
        
        if (entity.GetType() == typeof(Peasant))
        {
            Thread.Sleep(AttackSpeed);
            entity.Health -= Damage;
        }
        
        if (entity.GetType() == typeof(GuardTower))
        {
            Thread.Sleep(AttackSpeed);
            entity.Health -= Damage;
        }

        if (entity.GetType() == typeof(Footman))
        {
            Thread.Sleep(AttackSpeed);
            ((Footman)entity).Berserker();
            entity.Health -= Damage > ((Footman)entity).Armor? Damage : 0;
        }
        if (entity.GetType() == typeof(Military))
        {
            Thread.Sleep(AttackSpeed);
            entity.Health -= Damage > ((Military)entity).Armor? Damage : 0;
        }

        if (entity.Health <= 0) entity.CheckIsDestroyed();
    }
}