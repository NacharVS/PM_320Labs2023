using WeaponsInterfaces;

namespace Weapons.Heroes;

public class Engineer
{
    public void Upgrade(IUpgradable upgradableWeapon)
    {
        upgradableWeapon.Upgrade();
    }

    public void Repair(IRepairable repairableWeapon)
    {
        repairableWeapon.Repair();
    }
}