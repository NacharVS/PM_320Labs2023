using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWithInterfaces
{
    public class Shotgun : IWeapon
    {
        public int Damage { get; set; }
        public int Durability { get; set; }
        public int MaxShots { get; set; }
        public int CurrentShots { get; set; }

        public Shotgun(int damage, int durability, int maxShots)
        {
            Damage = damage;
            Durability = durability;
            MaxShots = maxShots;
            CurrentShots = maxShots;
        }

        public void Reload()
        {
            CurrentShots = MaxShots;
        }

        public void Repair()
        {
            Durability += 1;
        }

        public void Shoot()
        {
            if (Durability > 0 && CurrentShots > 0)
            {
                Durability -= 1;
                CurrentShots -= 1;
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("");
            }
        }

        public void Upgrade()
        {
            Damage += 3;
        }
    }
}
