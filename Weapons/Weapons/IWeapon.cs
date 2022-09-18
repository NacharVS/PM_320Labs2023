interface IWeapon : IReloadeble, IRepairable, IUpgradeble
{
    int Damage { get; set; }

    void SingleShoot();
}