class FootMan : Military
{
    public FootMan(int health, int cost, string name, int speed, int damage, 
        int attackSpeed, int armor) : base(health, cost, name, speed, damage,
        attackSpeed, armor) { }

    public override void GetDamage(int dmg)
    {
        base.GetDamage(dmg);
        
        if (health <= maxHealth / 3 && health > 0)
        {
            Berserker();
        }
    }

    public void Berserker()
    {
        attackSpeed += attackSpeed / 2;
        damage += damage / 4;
        Console.WriteLine($"{name} in berserker mode");
    }

    public void Stun(Unit unit)
    {
        Random rnd = new Random();
        int chance = rnd.Next(1, 11);    //chance to stun is 10% 

        if (chance == 1)
        {
            unit.GetStun();
        }
    }

    public override void Attack(Unit unit)
    {
        Stun(unit);
        base.Attack(unit);
    }
}
