using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleWarcraft
{
    public class Blacksmith: Unit
    {
        public delegate void UpgradeDelegate();
        public event UpgradeDelegate UpgradeEvent;

        String name = "Blacksmith";
        int level = 0;
        int upgradeSpeed = 0;

        public Blacksmith(String name, int level, int upgradeSpeed, int health, int cost)
        {
                this.name = name;
                this.level = level;
                this.upgradeSpeed = upgradeSpeed;
        }

        public int Timer
        {
            get {
                System.Threading.Thread.Sleep(upgradeSpeed * 1000);
                UpgradeEvent?.Invoke();
                return upgradeSpeed; 
            }
            set
            {
                upgradeSpeed = value;    
            }
        }

        public void UpgradeArrow(Unit unit)
        {
            if (unit is Archer archer)
            {
                Console.WriteLine($"- upgrade arrow {upgradeSpeed} second...");
                upgradeSpeed = Timer;

                archer.arrowCount += 2 * level;
            }
        }

        public void UpgradeBow(Unit unit)
        {
            if (unit is Archer archer)
            {
                Console.WriteLine($"- upgrade bow {upgradeSpeed} second...");
                upgradeSpeed = Timer;

                archer.damage += 10 * level;
            }
        }

        public void UpgradeWeapon(Unit unit)
        {
            if (unit is Military military)
            {
                Console.WriteLine($"- upgrade weapon {upgradeSpeed} second...");
                upgradeSpeed = Timer;
               
                military.armor += 10 * level;
            }
        }
    }
}
