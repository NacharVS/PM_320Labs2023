class Mechanic
{
    public void UpgradeWeapon(IUpgradeble weapon)
    {
        weapon.UpgradeDamage();
    }

    public void RepairWeapon(IRepairable weapon)
    {
        weapon.Repair();
    }

    public void ShowInfo(IRepairable weapon)
    {
        weapon.ShowInfo();
    }
}