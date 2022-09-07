using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWarcraft
{
    public class Blacksmith: Unit
    {
        String name = "Blacksmith";
        int level = 0;
        int upgradeSpeed = 0;

        public Blacksmith(String name, int level, int upgradeSpeed, int health, int cost)
        {
                this.name = name;
                this.level = level;
                this.upgradeSpeed = upgradeSpeed;
        }

        public void UpgradeArrow(Unit unit)
        {
            if (unit is Archer archer)
            {
                archer.arrowCount += 2 * level;
            }
        }

        public void UpgradeBow(Unit unit)
        {
            if (unit is Archer archer)
            {
                archer.damage += 10 * level;
            }
        }

        public void UpgradeWeapon(Unit unit)
        {
            if (unit is Military military)
            {
                military.armor += 10 * level;
            }
        }
    }
}
