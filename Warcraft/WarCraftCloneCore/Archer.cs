﻿namespace WarCraftCloneCore;

public class Archer : Range
{
    private int _arrowCount = 32;

    public Archer(Logger logger, string name, double health, int cost, int lvl,
        double maxHp, double speed, double damage, double attackSpeed,
        double armor, double range, double mana)
        : base(logger, name, health, cost, lvl, maxHp, speed,damage,attackSpeed,armor,range,mana)
    {
    }

    public override void Attack(Unit attackedUnit)
    {
        if (_arrowCount > 0)
        {
            base.Attack(attackedUnit);
        }
        else
        {
            _logger.Log("Arrows count not enough!");
        }
    }

    public void UpgradeArrow()
    {
        if (GetState())
        {
            return;
        }
        SetDamage(GetDamage() + 4);
    }

    public void UpgradeBow()
    {
        if (GetState())
        {
            return;
        }
        _arrowCount += 10;
    }
}