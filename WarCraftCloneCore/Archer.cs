namespace WarCraftCloneCore;

public class Archer : Range
{
    private int _arrowCount = 32;

    public Archer(string name, double health, int cost, int lvl,
        double maxHp, double speed, double damage, double attackSpeed,
        double armor, double range, double mana)
        : base(name, health, cost, lvl, maxHp, speed,damage,attackSpeed,armor,range,mana)
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
            Console.WriteLine("Arrows count not enough!");
        }
    }

    public void UpgradeArrow()
    {
        if (GetState() == false)
        {
            return;
        }
        SetDamage(GetDamage() + 4);
    }

    public void UpgradeBow()
    {
        if (GetState() == false)
        {
            return;
        }
        _arrowCount += 10;
    }
}