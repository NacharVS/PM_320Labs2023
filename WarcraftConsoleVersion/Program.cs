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

        Console.WriteLine("\nHi, dear player! You can choose Guard Towers(1), Peasant(2), Footman(3), Mage(4), Dragon(5), Archer(6)");
        Console.WriteLine("\nWrite name first character:");

        first = Game.AddUnit(Console.ReadLine(), first);

        Console.WriteLine("\nWrite name second character:");

        second = Game.AddUnit(Console.ReadLine(), second);

        newGame.GameStart(first, second);

        Military archer = new Military(550, 425, "123", 1, 1, 27, 2, 2);
        archer = new Archer(550, 425, "123", 1, 1, 27, 2, 2, 60);
        Blacksmith blacksmith = new Blacksmith(1200, "Blacksmith", 5);

    }

}