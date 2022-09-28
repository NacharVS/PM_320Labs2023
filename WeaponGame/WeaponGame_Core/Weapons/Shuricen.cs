using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponGame_Core.Interfaces;

namespace WeaponGame_Core.Weapons
{
    public class Shuricen : IMeleeWeapon
    {

        int endurance = 80;
        int damage = 5;
        int count = 50;
        public void Upgrade()
        {
            damage += 10;
            Log($"{this.GetType().Name} upgraded, it's damage: {damage}");
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
        public void Repair() // UPGRADE
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
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
