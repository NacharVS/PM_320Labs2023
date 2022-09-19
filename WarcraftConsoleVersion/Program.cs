using System;
using System.Threading;
using System.Xml.Linq;

public class Program
{
    private static void Main(string[] args)
    {
        //Game
        GuardTowers GuardTowers = new(50, 20, "Tower", 1, 25, 10, 2);
        Military Military = new(100, 100, "Military", 1, 1, 5, 1, 1);
        //newGame.GameStart(GuardTowers, Military);

        Unit first = new Unit(20, 30, "Unit", 10);
        Unit second = new Unit(20, 30, "Unit", 10);

        Console.WriteLine("Create game! Write name game:");
        Game newGame = new(Console.ReadLine());

        Console.WriteLine("\nHi, dear player! You can choose Guard Towers(1), Peasant(2), Footman(3), Mage(4), Dragon(5) or Archer(6)");
        Console.WriteLine("To finish adding units, write 'stop'");
        
        Game.AddCharaters();
        Game.getAllCharacters();

        int codeOne = 0;
        int codeTwo = 1;

        Console.WriteLine("Choose two characters for fight!(Firstly first, after second)");

        codeOne = Convert.ToInt32(Console.ReadLine());
        codeTwo = Convert.ToInt32(Console.ReadLine());

        newGame.GameStart(codeOne, codeTwo);
        //Unit archer;

        Archer archer = new(550, 425, "Archer", 1, 1, 27, 2, 2, 60);

        //Console.WriteLine(archer.skillPoint);

        Blacksmith blacksmith = new Blacksmith(1200, "Blacksmith", 5, 1);

        /*Console.WriteLine(archer.damage);

        blacksmith.UpgradeBow(archer);

        Console.WriteLine(archer.damage);

        Console.WriteLine(archer.armor);

        blacksmith.UpgradeArmor(archer);

        Console.WriteLine(archer.armor);*/
    }

}