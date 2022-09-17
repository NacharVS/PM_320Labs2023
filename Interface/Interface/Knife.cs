using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWithInterface
{
    class Knife : IMeleeWeapons, IThrowingWeapons
    {
        public int _meleeeDamage = 15;
        public int _throwDamage = 15;

        public int MeleeDamage
        {
            get { return _meleeeDamage; }
            set { _meleeeDamage = value; }
        }

        public int ThrowDamage
        {
            get { return _throwDamage; }
            set { _throwDamage = value; }
        }

        public void MeleeHit()
        {
            Console.WriteLine($"Stab with {MeleeDamage} damage");
        }

        public void ThrowHit()
        {
            Console.WriteLine($"Knife throw with {ThrowDamage} damage");
        }
    }
}
