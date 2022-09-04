class Archer : Military
{
    public Archer(int health, int cost, string name, int speed, int damage,
                  int attackSpeed, int armor, int arrowCount) : base(health,
                  cost, name, speed, damage, attackSpeed, armor)
    {
        this.arrowCount = arrowCount;
    }

    int arrowCount;

    public override void Attack(Unit unit)
    {
        if (arrowCount > 0)
        {
            base.Attack(unit);
            arrowCount--;
        }
        else
        {
            Console.WriteLine("Arrow count is empty");
        }
    }

    public override void UpgradeBow()
    {
        arrowCount += 10;
    }
}