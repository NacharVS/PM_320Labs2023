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
                Console.WriteLine($"{GetType().Name} ударил с уроном {MleeDamage}");
            }
            else
            {
                Console.WriteLine($"{GetType().Name} не смог ударить");
            }
        }

        public void Repair()
        {
            Durability += 1;
            Console.WriteLine($"{GetType().Name} был починен");
        }

        public void Throw()
        {
            Console.WriteLine($"{GetType().Name} был выброшен с уроном {ThrowDamage}");
        }

        public void Upgrade()
        {
            MleeDamage += 3;
            Console.WriteLine($"{GetType().Name} был улучшен");
        }
    }
}