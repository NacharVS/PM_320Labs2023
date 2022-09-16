namespace WeaponGame
{
    public interface IWeapon : IUpgradable, IReloadable, IRepairible
    {
        int Damage { get; set; }

        void SingleShoot();
    }
}