namespace Warcraft.Core;

public class Mage : Ranged
{
    private const int HealCost = 6;

    public Mage(int health, int cost, string name, int level, int speed,
        int attackSpeed, int attackRange) : base(health, cost, name, level,
        speed, attackSpeed, attackRange)
    {
    }

    public void Fireball()
    {
    }

    public void Blizzard()
    {
    }

    public void Heal(Unit target)
    {
        if (!target.IsDestroyed && target.Health < target.MaxHealth &&
            Mana >= HealCost)
        {
            target.GetHealed();
            Mana -= HealCost;
        }
    }

    public override void Move()
    {
    }
}