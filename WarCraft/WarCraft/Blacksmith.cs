using ConsoleWarcraftProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCraft
{
    class Blacksmith : Moveable
    {
        public int ArmorCount = 10;
        public int WeaponCount = 10;
        public int BowCount = 5;
        private List<Military> Players;
        public Blacksmith(string name, int health, int cost,
            int lvl, bool isDestroyed, int speed, params Military[] players) : base(name, 
                health, cost, lvl, isDestroyed, speed)
        {
            Players = players.ToList();
        }

        public void UpgradeArmor() { }

        public void UpgradeWeapon() { }

        public void UpgradeBow() { }
    }
}
