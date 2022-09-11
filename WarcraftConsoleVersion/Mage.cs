internal class Mage : RangeMan
{
    public Mage(int healthPoint, int cost, string name, int level, int speed, int damage, int attackSpeed, int armor, int range, int mana) : 
        base(healthPoint, cost, name, level, speed, damage, attackSpeed, armor, range, mana)
    {
    }

    public override void FireBall(Unit enemy)
    {
        mana = mana - 30;
        enemy.healthPoint = enemy.healthPoint - damage - 15;
    }

    public override void Blizzard(Unit enemy)
    {
        mana = mana - 30;
        enemy.healthPoint = enemy.healthPoint - damage - 15;
    }

    public override void Heal()
    {
        mana = mana - 50;
        healthPoint = healthPoint + 50;
    }
    public override void Attack(Unit enemy)
    {
        int i = rnd.Next(1, 20);
        if (i == 1 && mana > 29)
        {
            FireBall(enemy);
        }
        else if (i == 2 && mana > 29)
        {
            Blizzard(enemy);
        }
        else if (i == 3 && mana > 49)
        {
            Heal();
        }
        else
        {
            enemy.healthPoint = enemy.healthPoint - damage;
        }
        enemy.Alive();
    }
}