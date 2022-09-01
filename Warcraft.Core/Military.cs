namespace Warcraft.Core;

public abstract class Military : Movable
{
    public int Damage { get; private set; }
    public int AttackSpeed { get; private set; }
    public int Armor { get; private set; }

    protected Military(int health, int cost, string name, int level, int speed,
        int attackSpeed) : base(health, cost, name, level, speed)
    {
        AttackSpeed = attackSpeed;
    }

    public override void GetDamage(int damage)
    {
        damage -= Armor;
        base.GetDamage(damage);
    }

    public void Attack(Unit target, int damage)
    {
        if (!target.IsDestroyed)
            target.GetDamage(damage);
    }
}