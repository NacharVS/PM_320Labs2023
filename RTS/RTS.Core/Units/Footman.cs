using System;
using System.Threading;
using RTS.Core;

public class Footman : Military
{
    private int _meaningOfUsingBerserker;
    public Footman(int health, int cost, string? name, int level, int speed, int damage, int attackSpeed, int armor) 
        : base(health, cost, name, level, speed, damage, attackSpeed, armor)
    {
        _meaningOfUsingBerserker = (int)(Health * 0.3);
    }

    private void Berserker()
    {
        if (Health < _meaningOfUsingBerserker) AttackSpeed /= 2;
    }

    public void Stun(Unit entity)
    {
        
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
        this.Berserker();
        this.CheckIsDestroyed();
    }
}