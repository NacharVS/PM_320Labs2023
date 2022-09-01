namespace Warcraft.Core;

public class GuardTower : Unit
{
    public int Damage { get; private set; }
    public int Range { get; private set; }
    public int AttackSpeed { get; private set; }

    public GuardTower(int health, int cost, string name, int level, int range,
        int attackSpeed, int damage) : base(health, cost, name, level)
    {
        Range = range;
        AttackSpeed = attackSpeed;
        Damage = damage;
    }

    public void Attack(Unit target)
    {
        target.GetDamage(Damage);
    }
}