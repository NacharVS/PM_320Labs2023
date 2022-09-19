using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWithInterface
{
    public class Shuriken : IThrowingWeapons
    {
        public int ThrowDamage { get; set; }

        public Shuriken (int throwDamage)
        {
            ThrowDamage = throwDamage;
        }

        public void ThrowHit()
        {
            Console.WriteLine($"Shuriken throw with {ThrowDamage} damage");
        }
    }
}
