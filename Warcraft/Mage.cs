class Mage : Range
{
    public Mage(int health, int cost, string name, int speed, int damage, int attackSpeed, int armor, int range, int mana) : base(health, cost, name, speed, damage, attackSpeed, armor, range, mana) { }
    
    public void FireBall(Unit unit)
    {
        unit.GetFire(damage, 2);    //fire will attack unit by 2 moves
        mana -= 20;
    }

    public void Blizzard(Unit unit)
    {
        unit.GetFreeze(damage, 1);  //blizzard attack unit by 1 move
        mana -= 15;
    }

    public void Heal()
    {
        
        HealthChanged(0 - (maxHealth / 10));  //unit will hill to 10% by max health
        mana -= 15;
    }

    public override void Attack(Unit unit)
    {
        Random rnd = new Random();

        while (!IsDestroyed() && !unit.IsDestroyed())
        {
            Thread.Sleep(attackSpeed);

            if (IsDestroyed() || unit.IsDestroyed())
            {
                return;
            }

            int chance = rnd.Next(1, 5);

            if (chance == 1 && mana >= 20)       //fire ball need 20 mana to use
            {
                FireBall(unit);
            }
            else if (chance == 2 && mana >= 15)  //blizzard need 15 mana to use
            {
                Blizzard(unit);
            }
            else if (chance == 3 && mana >= 15)   //heal need 15 mana to use
            {
                Heal();
            }
            else if (chance == 4)
            {
                base.Attack(unit);
            }
            else
            {
                Console.WriteLine("Need mana");
            }
        }
    }
}