using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCraft
{
    class Blacksmith : Unit
    {
        public static int ArmorCount = 10;
        public static int WeaponCount = 10;
        public static int BowCount = 5;

        public Blacksmith(string name, int health, 
            int cost, int lvl, bool isDestroyed) : 
            base(name, health, cost, lvl, isDestroyed)
        {
        }

        public void UpgradeArmor(Military pers) 
        {
            pers.Armor += ArmorCount; 
        }

        public void UpgradeWeapon(Military pers) 
        {
            pers.Damage += WeaponCount;
        }

        public void UpgradeBow(Archer pers) 
        {
            pers.ArrowCount += BowCount;
        }
    }
}
