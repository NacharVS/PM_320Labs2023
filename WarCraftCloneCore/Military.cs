public abstract class Military : Moveble
{
    private double _damage;
    private double _attackSpeed;
    private double _armor;

    public Military(string name, double health, int cost, int lvl,
        double maxHp, double speed, double damage, double attackSpeed, double armor)
        : base(name, health, cost, lvl, maxHp, speed)
    {
        _damage = damage;
        _attackSpeed = attackSpeed;
        _armor = armor;
    }

    public virtual void Attack(Unit attackedUnit)
    {
        Attack(attackedUnit, _damage);
    }

    public void Attack(Unit attackedUnit, double damage)
    {
        if (attackedUnit == this)
        {
            Console.WriteLine("Can't attack himself!");
            return;
        }

        else if (attackedUnit.GetHealth() - damage <= 0)
        {
            attackedUnit.SetState(true);
        }

        if (attackedUnit.GetState())
        {
            return;
        }

        attackedUnit.SetHealth(attackedUnit.GetHealth() - Math.Min(damage, damage - _armor));
    }

    public void SetDamage(double damage)
    {
        _damage = damage;
    }

    public double GetDamage()
    {
        return _damage;
    }

    public double GetAttackSpeed()
    {
        return _attackSpeed;
    }

    public void SetAttackSpeed(double attackSpeed)
    {
        _attackSpeed = attackSpeed;
    }

    public void UpgradeArmor()
    {
        _armor += 4;
    }
}
