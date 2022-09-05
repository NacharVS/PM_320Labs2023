using System;
using System.Collections.Generic;

namespace ConsoleWarcraft
{
    class Program
    {
        static void Main()
        {
            int count = 1;

            int player1 = 0;
            int player2 = 0;

            Mage mage1 = new Mage("Voland", 1000, 750, 100,  false, 100, 100, 100, 200, 200);
            Mage mage2 = new Mage("Potter", 1000, 50, 15, false, 100, 100, 100, 200, 200);
            Footman footman = new Footman("Worgen", 2500, 45000, 1000, 90, 30, false);
            // Dragon dragon = new Dragon("Sparky", 1000, 50, 15, false, 100, 100, 100, 200, 200);
            Unit[] units = new Unit[] {mage1, mage2, footman};
            


            Console.WriteLine();
            for (int i = 0; i < units.Length; i++)
            {
                Console.WriteLine($"{i+1} {units[i].name}  level: {units[i].level}  health {units[i].health}" );
            }
            Console.WriteLine();
            Console.Write("Player 1: choose hero: ");
            player1 = int.Parse(Console.ReadLine())-1;
            
            Console.Write("Player 2: choose hero: ");
            player2 = int.Parse(Console.ReadLine())-1;

            GameLogic game = new GameLogic(units[player1], units[player2]);
            game.run();

            //Console.ReadKey();
            
        }
        
        public void startGame(Unit unit1 , Unit unit2) {
            
        }

        public static void showMageAttack(Mage mage)
        {
            Console.WriteLine(mage.name + ": attack "+ mage.damage + " | mana: " + mage.mana);
        }
        
        public static void showFootmanAttack(Footman footman)
        {
            Console.WriteLine(footman.name + ": attack "+ footman.damage);
        }
        
        public static void showHealth(Unit unit)
        {
            Console.WriteLine(unit.name + ":  health:" + unit.health);
            Console.WriteLine();
        }
    }
}