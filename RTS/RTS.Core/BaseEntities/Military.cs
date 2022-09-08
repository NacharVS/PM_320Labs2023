using System;
using System.Reflection.Metadata;
using System.Threading;
using RTS.Core.Annotations.Units;

public abstract class Military : Movable
{
    public int Damage { get; set; }
    public int AttackSpeed { get; set; }
    public int Armor { get; set; }

    protected Military(int health, int cost, string? name, int level, int speed, int damage, int attackSpeed, int armor) 
        : base(health, cost, name, level, speed)
    {
        Damage = damage;
        AttackSpeed = attackSpeed;
        Armor = armor;
    }

    public virtual void Attack(Unit entity)
    {
        if (entity.IsDestroyed)
        {
            Console.WriteLine("игрок помер");
        }
        Thread.Sleep(AttackSpeed);
        entity.DealingDamage(this);
    }
    
    public override void DealingDamage(Military entity)
    {
        Health -= entity.Damage > Armor? entity.Damage : 0;
        this.CheckIsDestroyed();
    }
}