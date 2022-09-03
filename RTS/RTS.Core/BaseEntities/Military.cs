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

    public void Attack(Unit entity)
    {
        if (entity.IsDestroyed)
        {
            Console.WriteLine("игрок помер");
        }
        if (entity.GetType() == typeof(Footman))
        {
            Thread.Sleep(AttackSpeed);
            ((Footman)entity).Berserker();
            entity.Health -= Damage > ((Footman)entity).Armor? Damage : 0;
            NotifyAboutDamage(Damage, entity);
        }
        if (entity.GetType() == typeof(Military))
        {
            Thread.Sleep(AttackSpeed);
            entity.Health -= Damage > ((Military)entity).Armor? Damage : 0;
            NotifyAboutDamage(Damage, entity);
        }
        if (entity.GetType() == typeof(Mage))
        {
            Thread.Sleep(AttackSpeed);
            entity.Health -= Damage > ((Mage)entity).Armor? Damage : 0;
            NotifyAboutDamage(Damage, entity);
        }
        if (entity.GetType() == typeof(Archer))
        {
            Thread.Sleep(AttackSpeed);
            ((Archer)entity).DealingDamage(ref entity);
            NotifyAboutDamage(Damage, entity);
        }
        else
        {
            Thread.Sleep(AttackSpeed);
            entity.Health -= Damage;
            NotifyAboutDamage(Damage, entity);
        }
        
        entity.CheckIsDestroyed();
    }

    public void NotifyAboutDamage(int damage, Unit entity)
    {
        Console.WriteLine($"{this.Name} нанес удар силой в {this.Damage} игроку {entity.Name}");
    }
}