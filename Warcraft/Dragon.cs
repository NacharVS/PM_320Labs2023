class Dragon : Range
{
    public Dragon(int health, int cost, string name, int speed, int damage, int attackSpeed, int armor, int range, int mana) : base(health, cost, name, speed, damage, attackSpeed, armor, range, mana) { }

    public void FireBreach(Unit unit)
    {
        Random rnd = new Random();
        int chance = rnd.Next(1, 6);    //chance to fire breach is 20%

        if (chance == 1 && mana >= 10)  //fire breach need 10 mana to use
        {
            unit.GetFire(damage, 3);    //fire will attack unit by 3 moves
            mana -= 10;
        }
    }

    public override void Attack(Unit unit)
    {
        FireBreach(unit);
        base.Attack(unit);
    }
}