using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace WarCraft_3_ConsoleEdition
{
    class Program
    {
        static Dictionary<string, Unit> unitDict = new Dictionary<string, Unit>()
        {
            {"GuardTower", new GuardTower(15, 35 ,20 ,300, 150, "GuardTower", 1) },
            {"Footman", new Footman(15, 8, 10, 5, 100, 30, "Footman", 1) },
            {"Mage", new Mage(20, 100, 10, 6, 10, 5, 80, 45, "Mage", 1) },
            {"Dragon", new Dragon(30, 300, 20, 15, 20, 5, 200, 100, "Dragon", 1) },
            {"Archer", new Archer(100, 25, 10, 10, 5, 6, 70, 25, "Archer", 1) },
            {"Peasant", new Peasant(5, 30, 10, "Peasant", 1) },
            {"Blacksmith", new Blacksmith(4, 150, 200, "Blacksmith", 1) }
        };

        static void Healing()
        {
            foreach (var unit in unitDict)
            {
                unit.Value.health += 200;
            }
            Console.WriteLine("The battle is over. All fighters were healed.");
        }

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to this Game!");
                Console.WriteLine("Please, select 2 Units:");

                foreach (Unit value in unitDict.Values)
                {
                    Console.WriteLine(value.name);
                }

                Console.Write("Write name first Unit: ");
                string firstUnit = Console.ReadLine();

                Console.Write("Write name second Unit: ");
                string secondUnit = Console.ReadLine();

                Console.WriteLine();

                Game.StartGame(unitDict[firstUnit], unitDict[secondUnit]);

                Healing();
            }

            catch
            {
                Console.WriteLine("Wrong input!");
            }
        }
    }

    class Blacksmith : Unit
    {
        int buff;

        public Blacksmith (int buff, int health, int cost, string name, int level) : base(health, cost, name, level)
        {
            this.buff = buff;
        }

        public void UpgradeArmor(Unit unit)
        {
            if (unit is Military military) 
            {
                ((Military)unit).armor += buff;
            }
        }

        public void UpgradeWeapon(Unit unit)
        {
            if (unit is Military military)
            {
                ((Military)unit).damage += buff;
            }

            if (unit is GuardTower guardTower)
            {
                ((GuardTower)unit).damage += buff;
            }
        }

        public void UpgradeBow(Unit unit)
        {
            if (unit is Archer archer)
            {
                ((Archer)unit).arrowCount += buff;
            }
        }
    }
}
