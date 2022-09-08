using WarCraftCloneCore;

public abstract class Military : Moveble
{
    private double _damage;
    private double _attackSpeed;
    private double _armor;
    public Military(Logger logger,string name, double health, int cost, int lvl,
        double maxHp, double speed, double damage, double attackSpeed, double armor)
        : base(logger,name, health, cost, lvl, maxHp, speed)
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
            _logger.Log("Can't attack himself!");
            return;
        }

        if (attackedUnit.GetHealth() - damage <= 0)
        {
            attackedUnit.SetState(true);
        }

        if (attackedUnit.GetState())
        {
            return;
        }

        _logger.Log($"{GetName()} attack {attackedUnit.GetName()}");
        if (attackedUnit is Military militaryUnit)
        {
            militaryUnit.SetHealth(militaryUnit.GetHealth() - (_damage + _armor));
        }
        else
        {
            attackedUnit.SetHealth(attackedUnit.GetHealth() - damage);
        }
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
