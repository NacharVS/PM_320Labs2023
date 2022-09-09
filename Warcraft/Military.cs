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

    public override void HealthChanged(int dmg)
    {
        if (dmg < armor / 2)
        {
            base.HealthChanged(0);
        }
        else
        {
            base.HealthChanged(dmg - armor / 2);
        }
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

