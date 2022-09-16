using WeaponsInterfaces;

namespace Weapons.Heroes;

public class CounterTerrorist
{
    public List<IWeapon> WeaponInvent { get; set; }

    public CounterTerrorist()
    {
        WeaponInvent = new List<IWeapon>();
    }

    public void PickUpWeapon(IWeapon weapon)
    {
        WeaponInvent.Add(weapon);
    }

    public void Shoot(IWeapon weapon)
    {
        weapon.Shot();
    }

    public void Hit(IMeleeWeapon meleeWeapon)
    {
        meleeWeapon.Hit();
    }

    public void AutoShoot(IAutoShoot autoShootWeapon)
    {
        autoShootWeapon.AutoShoot();
    }

    public void Throw(IThrowable throwWeapon)
    {
        throwWeapon.Throw();
    }

    public void Reload(IReloadable reloadableWeapon)
    {
        reloadableWeapon.Reload();
    }
}