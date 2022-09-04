class Mage : Range
{
    public Mage(int health, int cost, string name, int speed, int damage, int attackSpeed, int armor, int range, int mana) : base(health, cost, name, speed, damage, attackSpeed, armor, range, mana) { }
    
    public void FireBall(Unit unit)
    {
        Random rnd = new Random();
        int chance = rnd.Next(1, 8);    //chance to fire ball is 1/7 

        if (chance == 1 && mana >= 20)  //fire breach need 20 mana to use
        {
            unit.GetFire(damage, 2);    //fire will attack unit by 2 moves
            mana -= 20;
        }
    }

    public void Blizzard(Unit unit)
    {
        Random rnd = new Random();
        int chance = rnd.Next(1, 5);    //chance to blizzard is 25%

        if (chance == 1 && mana >= 15)  //blizzard need 15 mana to use
        {
            unit.GetFreeze(damage, 1);  //blizzard attack unit by 1 move
            mana -= 15;
        }
    }

    public void Heal()
    {
        Random rnd = new Random();
        int chance = rnd.Next(1, 21);    //chance to heal is 5%

        if (chance == 1 && mana >= 15)  //heal need 15 mana to use
        {
            GetHeal(maxHealth / 10);  //unit will hill to 10% by max health
            mana -= 15;
        }
    }

    public override void Attack(Unit unit)
    {
        FireBall(unit);
        Blizzard(unit);
        Heal();
        base.Attack(unit);
    }
}