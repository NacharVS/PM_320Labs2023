using Interfaces;

namespace Weapons
{
    public class Pistol : ISingleShoot, IWeapon, IReload
    {
        int _damage = 3;
        public int Damage 
        {   
            get { return _damage; }
            set { _damage = value; } 
        }

        public void Reload()
        {
            Console.WriteLine("Pistol reload");
        }

        public void Repaire()
        {
            Console.WriteLine("Pistol repaire");
        }

        public void SingleShoot()
        {
            Console.WriteLine("Pistol single shoot");
        }

        public void Upgrade()
        {
            Console.WriteLine("Pistol upgrade");
        }
    }
}
