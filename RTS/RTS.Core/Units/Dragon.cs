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
    
    public override void DealingDamage(ref Unit entity)
    {
        Health -= ((Dragon)entity).Damage;
    }
}