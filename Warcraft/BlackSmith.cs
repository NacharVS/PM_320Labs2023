static class BlackSmith
{
    static public void UpgradeArmor()
    {
        List<Unit> units = Units.GetMilitary();

        foreach(Unit unit in units)
        {
            unit.UpgradeArmor();
        }
    }

    static public void UpgradeWeapon()
    {
        List<Unit> units = Units.GetMilitary();

        foreach(Unit unit in units)
        {
            unit.UpgradeWeapon();
        }
    }

    static public void UpgradeBow()
    {
        List<Unit> units = Units.GetArchers();

        foreach(Unit unit in units)
        {
            unit.UpgradeBow();
        }
    }
}