using RTS.Core.BaseEntities;
using RTS.Core.Logger;

namespace RTS.Core.Units;

public class GuardTower : Unit
{
    public int AttackRange { get; private protected set; }
    public int Damage { get; private protected set; }
    
    /// <summary>
    /// Attack speed in ms
    /// </summary>
    public int AttackSpeed { get; private protected set; }

    public GuardTower(int health, int cost, string? name, int level, int attackRange, int damage, int attackSpeed, ILogger logger) 
        : base(health, cost, name, level, logger)
    {
        AttackRange = attackRange;
        Damage = damage;
        AttackSpeed = attackSpeed;
    }

    private void Attack(Unit entity, int damage)
    {
        Thread.Sleep(AttackSpeed);
        entity.GetDamage(damage);
    }
    
    public void Attack(Unit entity)
    {
        Thread.Sleep(AttackSpeed);
        entity.GetDamage(Damage);
    }
}