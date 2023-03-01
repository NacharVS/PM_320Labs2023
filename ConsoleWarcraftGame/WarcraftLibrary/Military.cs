using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarcraftLibrary
{
    public class Military : Moveable
    {
        public int Armor;

        public Military(string name, int health, int cost, int lvl, bool isDestroyed, int speed, int damage, int attackSpeed, int armor) : base(name, health, cost, lvl, isDestroyed, speed, damage, attackSpeed)
        {
            this.Armor = armor;
        }

        public override string Attack(Unit unit, Blacksmith blacksmith) 
        {
            return " ";
        }
    }
}
