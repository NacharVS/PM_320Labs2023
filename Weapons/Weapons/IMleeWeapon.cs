interface IMleeWeapon : IRepairable, IUpgradeble
{
    int MleeDamage { get; }

    void Hit();
}