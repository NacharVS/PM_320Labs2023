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
        while (!IsDestroyed() && !unit.IsDestroyed())
        {
            Thread.Sleep(attackSpeed);

            if (this.IsDestroyed() || unit.IsDestroyed())
            {
                return;
            }
            else
            {
                unit.HealthChanged(damage);
            }
        }
    }
}