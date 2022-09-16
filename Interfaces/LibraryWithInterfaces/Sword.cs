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

        public void Upgrade()
        {
            MleeDamage += 3;
        }
    }
}
