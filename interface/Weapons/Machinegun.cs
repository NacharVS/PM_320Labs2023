using Interfaces;

namespace Weapons
{
    public class Machinegun : IAutoShoot, IWeapon, IReload, ISingleShoot
    {
        int _damage = 5;
        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }

        public void AutoShoot() 
        {
            Console.WriteLine("Machinegun auto shoot");
        }

        public void Reload()
        {
            Console.WriteLine("Machinegun reload");
        }

        public void Repaire()
        {
            Console.WriteLine("Machinegun repaire");
        }

        public void SingleShoot()
        {
            Console.WriteLine("Machinegun single shoot");
        }

        public void Upgrade()
        {
            Console.WriteLine("Machinegun upgrade");
        }
    }
}
