class FootMan : Military
{
    public FootMan(int health, int cost, string name, int speed, int damage,
        int attackSpeed, int armor) : base(health, cost, name, speed, damage, attackSpeed, armor)
    {
    }
    public override void Attack(Unit unit)
    {
        base.Attack(unit);
        Stun(unit);
    }

    public void Berserker()
    {
        if (health <= maxHealth / 4)
        {
            attackSpeed += 15;
            damage += 10;
            Console.WriteLine($"{name} in berserk mode");
        }
    }

    public void Stun(Unit unit)
    {
        Random rnd = new Random();
        int bashProcent = rnd.Next(1, 101);
        
        if (bashProcent % 17 == 0)
        {
            unit.GetStun();
        }    
    }
}
