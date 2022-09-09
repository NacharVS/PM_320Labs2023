class Dragon : Range
{
    public Dragon(int health, int cost, string name, int speed, int damage, int attackSpeed, int armor, int range, int mana) : base(health, cost, name, speed, damage, attackSpeed, armor, range, mana) { }

    public void FireBreach(Unit unit)
    {
        unit.GetFire(damage, 3);       //fire will attack unit by 3 moves
        mana -= 10;
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

            int chance = rnd.Next(1, 3);

            if (chance == 1 && mana >= 10)  //fire breach need 10 mana to use
            {
                FireBreach(unit);
            }
            else
            {
                base.Attack(unit);
            }
        }
    }
}