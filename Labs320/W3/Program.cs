using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{ 
    static void Main()
    {
        Peasant p = new Peasant(10, 20, 5, "Peasant");

        Dragon d = new Dragon(50, 150, 70, "Dragon", 20, 20, 10, 3, 20);

        GuardTower gt = new GuardTower(100, 100, 40, "Guard Tower", 10, 7, 2);

        Footman f = new Footman(40, 60, 20, "Footman", 5, 2, 5);

        Mage m = new Mage(40, 70, 35, "Mage", 5, 50, 6, 5, 10);

        BlackSmith blackSmith = new BlackSmith(30, "BlackSmith");       

        string winnerPerson = "/";

        while (!f.isDestroyed && !gt.isDestroyed)
        {
            f.Stun(gt);

            gt.Attack(f);

            f.Attack(gt);

            f.Berserker();

            blackSmith.UpgradeArmor(f);

            blackSmith.UpgradeWeapon(f);

            gt.Attack(f);

            if (f.isDestroyed)
            {
                winnerPerson = gt.name;
            }

            else
            {
                winnerPerson = f.name;
            }
        }

        Console.WriteLine(winnerPerson + " - winner");
    }
}
