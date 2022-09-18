using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcraft3
{
    internal class Mage:Range
    {
        int buff;
        public Mage(string name, int health, int cost, int lvl, int maxHP, int speed, int damage, int attackSpeed,
           int armor) : base(name, health, cost, lvl, maxHP, speed, damage, attackSpeed, armor)
        {

        }

        public void BuffAttack(Unit unit)
        {


        }

        public void FireBall(Unit unit)
        {
            unit.SetHealth(unit.GetHealth() - this.GetDamage() * 2);
        }
        public void Blizzard(Unit unit) 
        {
            unit.SetHealth(unit.GetHealth() - this.GetDamage() * 4);
        }
        public void Heal() 
        {
            this.SetHealth(this.GetHealth() + 20);
        }

    }
}
