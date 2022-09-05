using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCraft
{
    class Blacksmith : Unit
    {
        public int ArmorCount = 10;
        public int WeaponCount = 10;
        public int BowCount = 5;
        private List<Military> Players;

        public Blacksmith(string name, int health, 
            int cost, int lvl, bool isDestroyed) : 
            base(name, health, cost, lvl, isDestroyed)
        {
        }

        public void UpgradeArmor(Military pers) 
        {
            pers.Armor = pers.Armor + 1; 
        }

        public void UpgradeWeapon() { }

        public void UpgradeBow() { }
    }
}
