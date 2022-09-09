class FootMan : Military
{
    public FootMan(int health, int cost, string name, int speed, int damage, 
        int attackSpeed, int armor) : base(health, cost, name, speed, damage,
        attackSpeed, armor)
    {
        HealthChangedEvent += Berserker;
    }

    private bool berserkMode;

    public void Berserker(int _)
    {
        if (isDestroyed)
        {
            return;
        }
        
        if (berserkMode && health > maxHealth / 3)
        {
            berserkMode = false;
            attackSpeed -= attackSpeed / 3;
            damage -= damage / 5;
            Console.WriteLine($"{name} not in berserker mode");
        }
        else if (!berserkMode && health < maxHealth / 3)
        {
            attackSpeed += attackSpeed / 2;
            damage += damage / 4;
            berserkMode = true;
            Console.WriteLine($"{name} in berserker mode");
        }

    }

    public void Stun(Unit unit)
    {
        Random rnd = new Random();
        int chance = rnd.Next(1, 5);    //chance to stun is 25% 

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
