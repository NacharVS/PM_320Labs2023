namespace WeaponGame.Characters
{
    public class Warrior
    {
        private List<IWeapon> inventory = new List<IWeapon>();
        public string Name { get; }

        public Warrior(string name)
        {
            Name = name;
        }

        public void PickUpWeapon(IWeapon weapon)
        {
            inventory.Add(weapon);
        }

        public void Attack(IWeapon weapon)
        {
            weapon.SingleShoot();
        }

        public void MultiAttack(ITripleShoot weapon)
        {
            weapon.TripleShoot();
        }

        public void MeleeAttack(IMeleeWeapon weapon)
        {
            weapon.MeleeAttack();
        }

        public void Throw(IThrowable weapon)
        {
            weapon.Throw();
        }

        public void ReloadItem(IReloadable item)
        {
            item.Reload();
        }
    }
}