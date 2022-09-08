namespace WarCraftCloneCore;

public class Blacksmith : Moveble
{
    public Blacksmith(Logger logger,string name, double health, int cost, int lvl,
        double maxHp, double speed) : base(logger, name, health, cost, lvl, maxHp, speed)
    {
    }

    public void UpgradeArrow(List<Unit> units)
    {
        foreach (var unit in units)
        {
            if (unit is Archer archerUnit)
            {
                archerUnit.UpgradeArrow();
            }
        }
    }

    public void UpgradeBow(List<Unit> units)
    {
        foreach (var unit in units)
        {
            if (unit is Archer archerUnit)
            {
                archerUnit.UpgradeBow();
            }
        }
    }

    public void UpgradeArmor(List<Unit> units)
    {
        foreach (var unit in units)
        {
            if (unit is Military archerUnit)
            {
                archerUnit.UpgradeArmor();
            }
        }
    }
}