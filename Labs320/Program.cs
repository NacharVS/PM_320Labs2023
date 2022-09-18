// Turushkin Sergey, 320P, "Warcraft"

using Units.BaseClasses;
using Units.BaseUnits;

namespace Warcraft
{
    internal static class Program
    {
        static void Main()
        {
            var peasant = new Peasant(100, 1.5, "peasant", 1, 2.4);
            peasant.action = new ConsoleAction();
            var footman = new Footman(150, 2.2, "footman", 1, 2.2, 30, 1.1, 50);
            footman.action = new ConsoleAction();
            var mage = new Mage(50, 15, "mage", 1, 2, 50, 2, 10, 7, 80);
            mage.action = new ConsoleAction();
            var guardTower = new GuardTower(450, 50, "guardTower", 1, 5, 50, 1);
            guardTower.action = new ConsoleAction();
            var dragon = new Dragon(1000, 150, "dragon", 1, 5.5, 100, 3, 0, 8, 500);
            dragon.action = new ConsoleAction();

            {
                Console.WriteLine(guardTower.health);
                dragon.Attack(guardTower);
                Console.WriteLine(guardTower.health);
                
                Console.WriteLine();

                Console.WriteLine(dragon.health);
                guardTower.Attack(dragon);
                Console.WriteLine(dragon.health);

                Console.WriteLine();

                Console.WriteLine(mage.health);
                guardTower.Attack(mage);
                Console.WriteLine(mage.health);
                if (mage.isDestroyed) { Console.WriteLine("die"); }

                Console.WriteLine();
            }


            {
                var units = new List<Military> {footman, mage, dragon};
                Random random = new Random();

                while (units.Count > 1)
                {
                    var unit1 = random.Next(0, units.Count);
                    var unit2 = random.Next(0, units.Count);

                    units[unit1].Attack(units[unit2]);
                    units.Remove(units[unit2]);
                }

                Console.WriteLine($"Final is win: {units[0].name}");
            }
        }
    }
}