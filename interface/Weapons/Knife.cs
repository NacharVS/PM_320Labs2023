using Interfaces;


namespace Weapons
{
    public class Knife : IThrowable, IMeleeWeapon
    {
        int _damage = 2;
        public int Damage 
        {   
            get { return _damage; } 
            set { _damage = value; } 
        }

        int _throwDamage = 1;
        public int ThrowDamage 
        { 
            get { return _throwDamage; }
            set { _throwDamage = value; }
        }

        public void SingleShoot() 
        {
            Console.WriteLine("Knife hit");
        }

        public void Upgrade() 
        {
            Console.WriteLine("Knife upgrade");
        }

        public void Throw() 
        {
            Console.WriteLine("Knife throw");
        }

        public void Repaire()
        {
            Console.WriteLine("Knife repaire");
        }
    }
}