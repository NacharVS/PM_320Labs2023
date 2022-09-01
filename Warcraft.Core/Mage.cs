namespace Warcraft.Core;

public class Mage : Ranged
{
    private const int HealCost = 6;
    private const int FireballDamage = 4;
    private const int FireballManaCost = 12;
    private const int BlizzardDamage = 4;
    private const int BlizzardManaCost = 10;

    public Mage(int health, int cost, string name, int level, int speed,
        int attackSpeed, int attackRange) : base(health, cost, name, level,
        speed, attackSpeed, attackRange)
    {
    }

    public void Fireball(Unit target)
    {
        if (Mana >= FireballManaCost)
            Attack(target, FireballDamage);
    }

    public void Blizzard(Unit target)
    {
        if (Mana >= BlizzardManaCost)
            Attack(target, BlizzardDamage);
    }

    public void Heal(Unit target)
    {
        if (Mana >= HealCost)
        {
            target.GetHealed();
            Mana -= HealCost;
        }
    }

    public override void Move()
    {
    }
}