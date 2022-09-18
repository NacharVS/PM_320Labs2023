public class Mage : Range
{
    private double _fireBallManaCost = 5;
    private double _fireBallDamage = 10;
    private double _blizzardManaCost = 7;
    private double _blizzardDamage = 12;
    private double _healManaCost = 10;
    private double _heal = 100;
    private double _healDebuffManaCost = 100;
    private int _healDebuffingPeriod = 2;
    public Mage(Logger logger, string name, double health, int cost, int lvl,
    double maxHp, double speed, double damage, double attackSpeed,
                        double armor, double range, double mana)
        : base(logger,name, health, cost, lvl, maxHp, speed, damage, attackSpeed, 
                                                        armor, range, mana)
    {
    }
    public void FireBall(Unit attackedUnit)
    {
        if(GetManaRes() < _fireBallManaCost)
        {
            _logger.Log("Not have a mana!");
            return;
        }
        else if(GetState())
        {
            _logger.Log("Dead!");
            return;
        }
        _logger.Log($"{attackedUnit} was hit fireball!");
        Attack(attackedUnit, _fireBallDamage);
        SetMana(_fireBallManaCost);
    }

    public void Blizzard(Unit attackedUnit)
    {
        if (GetManaRes() < _blizzardManaCost)
        {
            _logger.Log("Not have a mana!");
            return;
        }
        if (GetState())
        {
            _logger.Log("Dead!");
            return;
        }
        _logger.Log($"{attackedUnit} caught in a blizzard!");
        Attack(attackedUnit, _blizzardDamage);
        SetMana(_fireBallManaCost);
    }

    public void Heal(Unit selectedUnit)
    {
        if (GetManaRes() < _healManaCost)
        {
            _logger.Log("Not have a mana!");
            return;            
        }
        else if (GetState())
        {
            _logger.Log("Dead!");
            return;
        }
        else if (selectedUnit.HealDebuffPeriod > 0)
        {
            _logger.Log($"{selectedUnit} have a heal debuff! Debuff will disappear " +
                        $"after {selectedUnit.HealDebuffPeriod} health changes.");
            return;
        }
        
        if (selectedUnit.GetHealth() + _heal > selectedUnit.GetMaxHealth())
        {
            selectedUnit.SetHealth(selectedUnit.GetMaxHealth());
        }
        else
        {
            selectedUnit.SetHealth(selectedUnit.GetHealth() + _heal);
        }
        SetMana(_healManaCost);
    }

    public void AntiHealDebuff(List<Unit> units)
    {
        if(GetManaRes() < _healDebuffManaCost)
        {
            _logger.Log("Not have a mana!");
            return;
        }
        else if (GetState())
        {
            _logger.Log("Dead!");
            return;
        }
        
        foreach(var unit in units)
        {
            if(unit is not Mage)
            {
                unit.HealDebuffPeriod = _healDebuffingPeriod;
            }
        }
        SetMana(_healManaCost);
    }
}
