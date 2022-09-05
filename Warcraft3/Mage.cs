using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcraft3
{
    internal class Mage:Range
    {
        public Mage(int range, int mana) : base(range, mana)
        {
        }
        public Mage()
        {

        }

        public void FireBall()
        { 

        }
        public void Blizzard(Unit unit) 
        {
            unit.SetHealth(unit.GetHealth() - this.GetDamage() * 5);
        }
        public void Heal() 
        {
            this.SetHealth(this.GetHealth()+ 20);
        }

    }
}
