class Mage : Range
{
    public Mage(int health, int cost, string name, int speed, int damage,
        int attackSpeed, int armor, int mana) : base(health, cost, name, speed, damage, attackSpeed, armor, mana)
    {
        
    }
    public void FireBall(Unit unit)
    {
        unit.GetFire(10);
        mana -= 45;
    }

    public void Blizzard(Unit unit)
    {
        unit.GetBlizzard(13);
        mana -= 60;
    }

    public void Heal()
    {
        GetHeal(10);
        mana -= 10;
    }

    public override void Attack(Unit unit)
    {
        if (mana >= 60)
        {
            Blizzard(unit);
        }

        else if (mana >= 45 && mana < 60)
        {
            FireBall(unit);
        }

        else if (mana >= 10 && mana < 45)
        {
            Heal();
        }

        else if (mana < 10)
        {
            base.Attack(unit);
        }
    }
}