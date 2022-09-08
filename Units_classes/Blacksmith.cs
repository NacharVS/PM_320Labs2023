
 class Blacksmith
{
    public void Upgrade_weapon(Military unit)
    {
        unit.Damage += 5;
    }

    public void Upgrade_armour(Unit unit)
    {
        unit.Defence += 10;
    }

    public void Upgrade_bow(Archer unit)
    {
        unit.Radius += 1;
        unit.Damage += 5;
    }
}


