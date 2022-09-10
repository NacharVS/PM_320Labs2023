public class Dragon : Range
{
    private double _fireBreathManaCost = 20;
    private double _fireBreathDamage = 45;
    public Dragon(Logger logger, string name, double health, int cost, int lvl,
    double maxHp, double speed, double damage, double attackSpeed,
                        double armor, double range, double mana)
        : base(logger, name, health, cost, lvl, maxHp, speed, damage, attackSpeed,
                                                        armor, range, mana)
    {
    }
    public void FireBreath(Unit attackedUnit)
    {
        if (GetManaRes() < _fireBreathManaCost)
        {
            _logger.Log("Not have a mana!");
            return;
        }
        else if (GetState())
        {
            _logger.Log("Dead!");
            return;
        }
        _logger.Log($"{attackedUnit} was hit firebreath!");
        Attack(attackedUnit, _fireBreathDamage);
        SetMana(_fireBreathManaCost);
    }
}