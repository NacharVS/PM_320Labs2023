using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWithInterface
{
    class Shuriken : IThrowingWeapons
    {
        public int _throwDamage = 5;

        public int ThrowDamage
        {
            get { return _throwDamage; }
            set { _throwDamage = value; }
        }

        public void ThrowHit()
        {
            Console.WriteLine($"Shuriken throw");
        }
    }
}
