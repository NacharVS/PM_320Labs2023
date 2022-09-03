using System;

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
            {"Archer", new Archer(12, 12, 5, 35, 5, 5, 70, 50, "Archer", 1) }
        };

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to this Game!");
                Console.WriteLine("Please, select 2 Units:");

                foreach (string keys in unitDict.Keys)
                {
                    Console.WriteLine(keys);
                }

                Console.Write("Write name first Unit: ");
                string firstUnit = Console.ReadLine();

                Console.Write("Write name second Unit: ");
                string secondUnit = Console.ReadLine();

                Game.StartGame(unitDict[firstUnit], unitDict[secondUnit]);
            }

            catch
            {
                Console.WriteLine("Wrong input!");
            }
        }
    }
}
