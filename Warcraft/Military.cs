abstract class Military : Moveble
{
    public Military(int health, int cost, string name, int speed, int damage,
                  int attackSpeed, int armor) : base(health, cost, name, speed)
    {
        this.damage = damage;
        this.attackSpeed = attackSpeed;
        this.armor = armor;
    }

    protected int damage;
    protected int attackSpeed;
    protected int armor;

    public virtual void Attack(Unit unit)
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

    public override void GetDamage(int dmg)
    {
        base.GetDamage(dmg - armor / 2);
    }

    public override void UpgradeArmor()
    {
        armor += 3;
    }

    public override void UpgradeWeapon()
    {
        damage += 10;
    }
}

