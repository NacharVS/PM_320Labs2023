abstract class Military : Moveble
{
    protected int damage;
    protected int attackSpeed;
    protected int armor;

    public Military(int health, int cost, string name, int speed, int damage,
        int attackSpeed, int armor) : base(health, cost, name, speed)
    {
        this.damage = damage;
        this.attackSpeed = attackSpeed;
        this.armor = armor;
    }
    virtual public void Attack(Unit unit) 
    {
        if (this.isDestroyed || unit.isDestroyed)
        {
            Console.WriteLine("THE END");
            return;
        }

        if (inStun == true)
        {
            Console.WriteLine($"{name} in stun, and he is scip this move!");
            inStun = false;
            return;
        }

        unit.GetDamage(damage);
    }

    public override void GetDamage(int dmg)
    {
        base.GetDamage(dmg - (dmg / armor));
    }
}

