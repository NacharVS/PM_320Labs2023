using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcraft3
{
    internal class Blacksmith:Moveble
    {
        public Blacksmith(string name, int health, int cost, int lvl, int maxHP, int speed) :
            base(name, health, cost, lvl, maxHP, speed)
        {

        }
        public Blacksmith(string name) 
        {

        }
        public void UpgradeArmor(List<Unit> unit,int countOfArmor)
        {
            foreach(Unit un in unit)
            {
                if (un is Military military)
                {
                    military.SetArmor(countOfArmor);
                }
            }
            
        }
        public void UpgradeWeapon(Archer archer,int damageAdd)
        {
            archer.SetDamage(damageAdd);
        }
        public void UpgradeBow(Archer archer, int ArrowCount)
        {
            archer.SetArrowCount(ArrowCount);
        }

    }
}
