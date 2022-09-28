using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponGame_Core.Interfaces;

namespace WeaponGame_Core.Weapons
{
    internal class Rifle : IWeapon
    {
        int endurance = 70;
        int damage = 60;

        public void Reload()
        {
            Log($"{this.GetType().Name} reloaded");
        }

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
