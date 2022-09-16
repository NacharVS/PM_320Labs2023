using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWithInterfaces
{
    public class Knife : IMleeWeapon, IThrowable
    {
        public int MleeDamage { get; set; }
        public int ThrowDamage { get; set; }
        public int Durability { get; set; }

        public Knife(int mleeDamage, int throwDamage, int durability)
        {
            MleeDamage = mleeDamage;
            ThrowDamage = throwDamage;
            Durability = durability;
        }

        public void Hit()
        {
            if (Durability > 0)
            {
                Durability -= 1;
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("");
            }
        }

        public void Repair()
        {
            Durability += 1;
        }

        public void Throw()
        {
            Console.WriteLine("");
        }

        public void Upgrade()
        {
            MleeDamage += 3;
        }
    }
}
