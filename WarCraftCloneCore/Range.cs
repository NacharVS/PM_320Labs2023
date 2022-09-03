public abstract class Range : Military
{
    private double _range;
    private double _mana;

    public Range(string name, double health, int cost, int lvl,
    double maxHp, double speed,double damage, double attackSpeed,
                        double armor, double range, double mana)
        :base(name, health, cost, lvl, maxHp, speed, damage, attackSpeed, armor)
    {
        _range = range;
        _mana = mana;
    }

    public double GetManaRes()
    {
        return _mana;
    }
    public void SetMana(double manaSet)
    {
        _mana = _mana - manaSet;
    }
}
