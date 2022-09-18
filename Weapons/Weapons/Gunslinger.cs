class Gunslinger
{
    List<IWeapon> inventory = new List<IWeapon>();

    public void PicUpWeapon(IWeapon weapon)
    {
        inventory.Add(weapon);
    }

    public void Fire(IWeapon weapon)
    {
        weapon.SingleShoot();
    }

    public void MultiFire(ITripleShoot weapon)
    {
        weapon.TripleShoot();
    }

    public void HitByMleeWeapon(IMleeWeapon weapon)
    {
        weapon.Hit();
    }

    public void ThrowThrowableWeapon(IThrowable weapon)
    {
        weapon.Throw();
    }

    public void Reload(IReloadeble weapon)
    {
        weapon.Reload();
    }
}
