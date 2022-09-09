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
        List<Unit> unitsList = new List<Unit> { };

        public Blacksmith(String name, int level, int upgradeSpeed, int health, int cost, List<Unit> unitsList)
        {
                this.name = name;
                this.level = level;
                this.upgradeSpeed = upgradeSpeed;
                this.health = health;
                this.cost = cost;
                this.unitsList = unitsList;
        }

        public int Timer
        {
            get {
                showTimeUpgrade(upgradeSpeed);
                UpgradeEvent?.Invoke();
                return upgradeSpeed; 
            }
            set
            {
                upgradeSpeed = value;    
            }
        }

        public void UpgradeArmor()
        {

         foreach(var hero in unitsList)
            {
                if (hero is Military military)
                {
                    Console.WriteLine($"- {hero.name} upgrade armor {upgradeSpeed} second...");
                    upgradeSpeed = Timer;
                    military.armor += 10 * level;

                }
            }            
        }

        public void UpgradeBow()
        {
            foreach (var hero in unitsList)
            {
                if (hero is Archer archer)
                {
                    Console.WriteLine($"- {archer.name} upgrade bow {upgradeSpeed} second...");
                    upgradeSpeed = Timer;
                    archer.arrowCount += 2;
                }
            }
        }
            
        public void UpgradeWeapon()
        {
            foreach (var hero in unitsList)
            {
                if (hero is Military military)
                {
                    Console.WriteLine($"- {hero.name}  upgrade weapon {upgradeSpeed} second...");
                    upgradeSpeed = Timer;
                    military.damage += 10 * level;
                }
            }
        }

        static void showTimeUpgrade(int time)
        {
            for (int i = 1; i <= time; i++)
            {
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine($"  second: {i}/{time}");
            }
        }
    }
}
