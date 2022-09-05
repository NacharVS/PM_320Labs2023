
static class Blacksmith
{
    public static void Upgrade_weapon(Military unit)
    {
        unit.Damage += 5;
    }

    public static void Upgrade_armour(Unit unit)
    {
        unit.Defence += 10;
    }

    public static void Upgrade_bow(Archer unit)
    {
        unit.Radius += 1;
        unit.Damage += 5;
    }
}


