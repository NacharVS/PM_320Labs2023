namespace WeaponsInterfaces;

public interface IWeapon : IReloadable, IUpgradable, IRepairable
{
    int Damage { get; set; }
    
    void Shot();
}