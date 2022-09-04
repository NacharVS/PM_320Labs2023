using System;
using System.Collections.Generic;
using System.Threading;
using RTS.Core;

public class Dragon : Range
{
    public Dragon(int health, int cost, string? name, int level, int speed, int damage, 
        int attackSpeed, int armor, int attackRange, int mana) 
        : base(health, cost, name, level, speed, damage, attackSpeed, armor, attackRange, mana)
    {
    }
    private Dictionary<string,int> SpellsCost = new()
    {
        {"FireBreath", 15},
    };

    public void FireBreath(Unit entity)
    {
        if (Mana > 0)
        {
            Mana -= SpellsCost["FireBall"];
            Thread.Sleep(AttackSpeed);
            entity.Health -= Damage;
            if (entity.Health <= 0) entity.CheckIsDestroyed();
        }
        else
        {
            Console.WriteLine("Мана бетте");
        }
    }
    
    public override void Attack(Unit entity)
    {
        if (entity.IsDestroyed)
        {
            Console.WriteLine("игрок помер");
        }

        Thread.Sleep(AttackSpeed);
        entity.DealingDamage(this);
        NotifyAboutDamage(Damage, entity);
    }
    
    public override void DealingDamage(Military entity)
    {
        Health -= Damage > entity.Armor ? Damage : 0;
        Console.WriteLine($"{this.Name}  {this.Health}");
        this.CheckIsDestroyed();
    }
}