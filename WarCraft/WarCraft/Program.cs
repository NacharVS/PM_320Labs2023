using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWarcraftProj
{
    class Program
    {
        static void Main(string[] args)
        {
            var footman = new Footman("footman", 100, 10, 1, false, 10, 10, 100, 1000);
            var mage = new Mage("mage", 200, 20, 1, false, 20, 20, 200, 2000, 20, 10);
            var dragon = new Dragon("dragon", 300, 30, 1, false, 30, 30, 300, 3000, 30, 20);
            var players = new List<Military> { footman, mage, dragon };
            var random = new Random();

            var player1 = players[random.Next(players.Count)];
            var player2 = players[random.Next(players.Count)];
            while (player2 == player1)
            {
                player2 = players[random.Next(players.Count)];
            }

            Console.WriteLine($"В игре участвуют {player1.Name} и {player2.Name}");
            Console.WriteLine();

            while (!player1.Death() && !player2.Death())
            {
                Console.WriteLine($"HP1: {player1.Health}");
                Console.WriteLine($"HP2: {player2.Health}");
                Console.WriteLine();
                int attack = random.Next(1, 3);
                int hit = random.Next(1, 3);

                switch (attack)
                {
                    case 1:
                        player1.Attack(attack);
                        
                        if (hit == 1)
                        {
                            Console.WriteLine($"Попадание");
                            player2.Hit(player1.Damage);
                        }
                        else
                        {
                            Console.WriteLine($"Промах");
                        }
                        break;
                    case 2:
                        player2.Attack(attack);

                        if (hit == 1)
                        {
                            Console.WriteLine($"Попадание");
                            player1.Hit(player2.Damage);
                        }
                        else
                        {
                            Console.WriteLine($"Промах");
                        }
                        break;
                }
            }

            if (!player1.IsDestroyed)
            {
                Console.WriteLine($"Выиграл {player1.Name}");
            }
            else
            {
                Console.WriteLine($"Выиграл {player2.Name}");
            }
        }
    }
}
