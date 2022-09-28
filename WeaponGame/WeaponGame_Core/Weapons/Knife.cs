using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponGame_Core.Interfaces;
namespace WeaponGame_Core.Weapons
{
    public class Knife : IMeleeWeapon
    {
        int damage = 15;
        int endurance = 60;
        int count = 14;
       
        public void Repair()
        {
            if (endurance + 10 <= 100)
            {
                endurance += 10;
                Log($"{this.GetType().Name} fixed, it's endurance: {endurance}");
            }
            else
            {
                endurance = 100;
                Log($"{this.GetType().Name} cannot be repaired, has maximum endurance: {endurance}");
            }
        }

        public void Throw()
        {
            if (count > 0)
            {
                Log($"{this.GetType().Name} thrown, it's count: {endurance}");
                count--;
            }
            else
            {
                Log($"{this.GetType().Name} cannot be throw, count: {count}");
            }
        }

        public void Upgrade()
        {
            damage += 10;
            Log($"{this.GetType().Name} upgraded, it's damage: {damage}");
        }
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
