class GuardTower : Unit
{
    public GuardTower(int health, int cost, string name, int range, int damage, int attackSpeed) : base(health, cost, name)
    {
        this.range = range;
        this.damage = damage;
        this.attackSpeed = attackSpeed;
    }
    
    int range;
    int damage;
    int attackSpeed;

    public void Attack(Unit unit)
    {
        if (unit.IsDestroyed() || this.isDestroyed)
        {
            Console.WriteLine("Game over");
            return;
        }

        if (isStun)
        {
            Console.WriteLine($"{name} scip this move because he's stunned");
            isStun = false;
            return;
        }

        unit.GetDamage(damage);
    }
}