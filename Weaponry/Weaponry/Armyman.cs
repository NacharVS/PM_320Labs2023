using Weaponry.Interfaces;

namespace Weaponry;

public class Armyman
{
    public List<IFiregun> Inventory { get; set; }

    public Armyman()
    {
        Inventory = new List<IFiregun>();
    }

    public void PickUpWeapon(IFiregun weapon)
    {
        Inventory.Add(weapon);
    }

    public void MeleeAttack(IMeleeWeapon meleeWeapon)
    {
        meleeWeapon.MeleeAttack();
    }

    public void Fire(IFiregun firegun)
    {
        firegun.SingleShoot();
    }

    public void AutoFire(IAutoShootFiregun autoShootFiregun)
    {
        autoShootFiregun.Autoshoot();
    }

    public void Reload(IReloadable reloadable)
    {
        reloadable.Reload();
    }

    public void Throw(IThrowable throwable)
    {
        throwable.Throw();
    } 
}