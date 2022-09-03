namespace Warcraft.Core;

public class GuardTower : Unit
{
    public int Damage { get; private set; }
    public int Range { get; private set; }
    public int AttackSpeed { get; private set; }

    public GuardTower(IEventLogger logger, int health, int cost, string name, int level, int range,
        int attackSpeed, int damage) : base(logger, health, cost, name, level)
    {
        Range = range;
        AttackSpeed = attackSpeed;
        Damage = damage;
    }

    public void Attack(Unit target)
    {
        if (target == this)
        {
            Log("Не могу атаковать себя");
            return;
        }
        target.Hit(Damage);
        Log($"Атаковал {target.Name} на {Damage} урона");
    }
}