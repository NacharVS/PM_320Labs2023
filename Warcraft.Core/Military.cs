namespace Warcraft.Core;

public abstract class Military : Movable
{
    public int Damage { get; protected set; }
    public int AttackSpeed { get; protected set; }
    public int Armor { get; protected set; }

    protected Military(int health, int cost, string name, int level, int speed,
        int attackSpeed) : base(health, cost, name, level, speed)
    {
        AttackSpeed = attackSpeed;
    }

    public override void Hit(int damage)
    {
        damage = Math.Min(damage, damage - Armor);
        base.Hit(damage);
    }

    public void Attack(Unit target)
    {
        Attack(target, Damage);
    }

    public void Attack(Unit target, int damage)
    {
        if (!IsDestroyed && target != this)
            target.Hit(damage);
    }
}