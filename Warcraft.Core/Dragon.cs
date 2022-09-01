namespace Warcraft.Core;

public class Dragon : Ranged
{
    private const int FireBreathManaCost = 12;
    private const int FireBreathDamage = 5;
    public Dragon(int health, int cost, string name, int level, int speed,
        int attackSpeed, int attackRange) : base(health, cost, name, level,
        speed, attackSpeed, attackRange)
    {
    }

    public void FireBreath(Unit target)
    {
        if (Mana >= FireBreathManaCost)
            Attack(target, FireBreathDamage);
    }


    public override void Move()
    {
    }
}