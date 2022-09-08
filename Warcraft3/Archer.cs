using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcraft3
{
    internal class Archer:Range
    {
        int arrowCount;
        public Archer(string name, int health, int cost, int lvl, int maxHP, int speed, int damage, int attackSpeed,
           int armor,int arrowCount) : base(name, health, cost, lvl, maxHP, speed, damage, attackSpeed, armor)
        {
            this.arrowCount = arrowCount;
        }
        public virtual void Attack(Unit unit)
        {
            if(arrowCount > 0)
            {
                unit.SetHealth(unit.GetHealth() - this.GetDamage());
                arrowCount--;
            }
            
        }

        public void SetArrowCount(int arrowCount)
        {
            this.arrowCount += arrowCount;
        }

    }
}
