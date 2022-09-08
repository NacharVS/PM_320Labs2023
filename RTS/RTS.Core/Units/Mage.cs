using System;
using System.Collections.Generic;
using System.Threading;
using RTS.Core;


public class Mage : Range
{
    public Mage(int health, int cost, string? name, int level, int speed, int damage, 
        int attackSpeed, int armor, int attackRange, int mana) :
        base(health, cost, name, level, speed, damage, attackSpeed, armor, attackRange, mana)
    {
    }

    private Dictionary<string,int> SpellsCost = new()
    {
        {"FireBall", 10},
        {"Blizzard", 12},
        {"Heal", 10}
    };

    public void FireBall(Unit entity)
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
    
    public void Blizzard(Unit entity)
    {
        if (Mana > 0)
        {
            Mana -= SpellsCost["Blizzard"];
            Thread.Sleep(AttackSpeed);
            entity.Health -= Damage;
            if (entity.Health <= 0) entity.CheckIsDestroyed();
        }
        else
        {
            Console.WriteLine("Мана бетте");
        }
    }
    
    public void Heal(Unit entity)
    {
        if (Mana > 0)
        {
            Mana -= SpellsCost["Heal"];
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
    }
    
    public override void DealingDamage(Military entity)
    {
        Health -= entity.Damage > Armor ? entity.Damage : 0;
        this.CheckIsDestroyed();
    }
}