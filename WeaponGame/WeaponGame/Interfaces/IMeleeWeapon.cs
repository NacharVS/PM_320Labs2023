namespace WeaponGame
{
    public interface IMeleeWeapon : IUpgradable, IRepairible
    {
        int MeleeDamage { get; set; }

        public void MeleeAttack();
    }
}