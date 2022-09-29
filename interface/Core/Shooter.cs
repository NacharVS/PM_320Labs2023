using Interfaces;
using Weapons;

namespace Core
{
    public class Shooter
    {
        List<IWeapon> inventory = new List<IWeapon>();


        public void PickUpItem(IWeapon item)
        {
            inventory.Add(item);
        }
        public void Fire(ISingleShoot weapon)
        {
            weapon.SingleShoot();
        }

        public void MultiFire(IAutoShoot weapon)
        {
            weapon.AutoShoot();
        }

        public void FireFromAllWeapons()
        {
            foreach (var item in inventory)
            {
                item.SingleShoot();
            }
        }

        public void Reload(IReload item)
        {
            item.Reload();
        }

        public void ThrowKnife(IThrowable weapon)
        {
            weapon.Throw();
        }
    }
}