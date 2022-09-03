using System.Threading;
using RTS.Core;

public class GuardTower : Unit
{
    public int AttackRange { get; private protected set; }
    public int Damage { get; private protected set; }
    
    public int AttackSpeed { get; private protected set; }

    public GuardTower(int health, int cost, string? name, int level, int attackRange, int damage, int attackSpeed) 
        : base(health, cost, name, level)
    {
        AttackRange = attackRange;
        Damage = damage;
        AttackSpeed = attackSpeed;
    }

    public void Attack(Unit entity)
    {
        Thread.Sleep(AttackSpeed);
        entity.Health -= Damage;
    }
}