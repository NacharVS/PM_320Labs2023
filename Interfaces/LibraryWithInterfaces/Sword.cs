using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWithInterfaces
{
    public class Sword : IMleeWeapon
    {
        public int MleeDamage { get; set; }
        public int Durability { get; set; }

        public Sword(int mleeDamage, int durability)
        {
            MleeDamage = mleeDamage;
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

        public void Upgrade()
        {
            MleeDamage += 3;
            Console.WriteLine($"{GetType().Name} был улучшен");
        }
    }
}