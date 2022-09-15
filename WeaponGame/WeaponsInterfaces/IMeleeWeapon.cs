namespace WeaponsInterfaces;

public interface IMeleeWeapon : IRepairable, IUpgradable
{
    int MeleeDamage { get; set; }
    
    void Hit();
}