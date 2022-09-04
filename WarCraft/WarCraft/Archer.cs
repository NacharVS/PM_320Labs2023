using ConsoleWarcraftProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCraft
{
    internal class Archer : Military
    {
        public int ArrowCount { get; set; } 
        public Archer(string name, int health, int cost, int lvl, bool isDestroyed, int speed, int damage, int attackSpeed, int armor) : base(name, health, cost, lvl, isDestroyed, speed, damage, attackSpeed, armor)
        {
        }

        public void UpgradeBow(int value)
        {
            ArrowCount += value;
        }

        public void Attack() { }
    }
}
