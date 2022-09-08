public class GuardTower : Unit
{
    private double _range;
    private double _damage;
    private double _attackSpeed;

    public GuardTower(Logger logger,string name, double health, int cost, int lvl,
    double maxHp, double range, double damage, double attackSpeed)
        : base(logger,name, health, cost, lvl, maxHp)
    {
        _range = range;
        _damage = damage;
        _attackSpeed = attackSpeed;
    }

    public void Attack(Unit attackedUnit)
    {
        attackedUnit.SetHealth(attackedUnit.GetHealth() - _damage);
    }
}
