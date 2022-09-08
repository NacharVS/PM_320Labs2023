using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcraft3
{
    internal class Range:Military
    {
        public int range;
        public int mana;


        public Range(int range, int mana)
        {
            this.range = range;
            this.mana = mana;
        }
        public Range(string name, int health)
        {

        }

        public Range(string name, int health, int cost, int lvl, int maxHP, int speed, int damage, int attackSpeed,
            int armor) : base(name, health, cost, lvl, maxHP, speed, damage, attackSpeed, armor)
        {

        }
    }
}
