using RTS.Core.EventArgs;

namespace RTS.Core.BaseEntities;

public abstract class Military : Movable
{
    public int Damage { get; private protected set; }
    
    /// <summary>
    /// Attack speed in ms
    /// </summary>
    public int AttackSpeed { get; private protected set; }
    public int Armor { get; private protected set; }

    protected Military(int health, int cost, string? name, int level, int speed, int damage, int attackSpeed, int armor) 
        : base(health, cost, name, level, speed)
    {
        Damage = damage;
        AttackSpeed = attackSpeed;
        Armor = armor;
    }

    public override void GetDamage(int damage)
    {
        RaiseOnHitEvent(this, new HitArgs(damage > Armor 
            ? damage - Armor : 0,
             Health));
    }

    private protected void Attack(Unit entity, int damage)
    {
        if (entity.IsDestroyed || IsDestroyed)
            return;
        
        Thread.Sleep(AttackSpeed);
        
        if (entity.IsDestroyed || IsDestroyed)
            return;
        
        Console.WriteLine($"\"{Name}\" attacks \"{entity.Name}\" ");
        entity.GetDamage(damage);
    }
    
    public void Attack(Unit entity)
    {
        Attack(entity, Damage);
    }

    public void UpgradeWeapon(int damageBuff)
    {
        Damage += damageBuff;
    }
    public void UpgradeArmor(int armor)
    {
        Armor += armor;
    }
}