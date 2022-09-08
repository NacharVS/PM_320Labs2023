using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarCraft;

namespace WarCraft
{
    class Program
    {
        static void Main(string[] args)
        {
            var footman = new Footman("Footman", 100, 10, 1, false, 10, 10, 100, 1000);
            var mage = new Mage("Mage", 200, 20, 1, false, 20, 20, 200, 2000, 20, 10);
            var dragon = new Dragon("Dragon", 300, 30, 1, false, 30, 30, 300, 3000, 30, 20);
            var archer = new Archer("Archer", 200, 20, 1, false, 20, 20, 200, 2000, 20);
            var blacksmith = new Blacksmith("Blacksmith", 100, 100, 1, false);
            var players = new List<Military> { footman, mage, dragon, archer };
            var random = new Random();

            var player1 = players[random.Next(players.Count)];
            var player2 = players[random.Next(players.Count)];
            while (player2 == player1)
            {
                player2 = players[random.Next(players.Count)];
            }

            Console.WriteLine($"Player1: {player1.Name}");
            Console.WriteLine($"Player2: {player2.Name}");
            Console.WriteLine();

            
            blacksmith.Upgrade(player1);
            blacksmith.Upgrade(player2);
            

            if (player1 is Archer pers1)
            {
                blacksmith.ArcherUpgrade(pers1);
            }
            if (player2 is Archer pers2)
            {
                blacksmith.ArcherUpgrade(pers2);
            }

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
                        Thread.Sleep(500);

                        switch (hit)
                        {
                            case 1:
                                Console.WriteLine($"Hit");
                                player2.Hit(player1.Damage);
                                break;
                            case 2:
                                Console.WriteLine($"Miss");
                                break;
                        }
                        break;
                    case 2:
                        player2.Attack(attack);
                        Thread.Sleep(500);

                        switch (hit)
                        {
                            case 1:
                                Console.WriteLine($"Hit");
                                player1.Hit(player2.Damage);
                                break;
                            case 2:
                                Console.WriteLine($"Miss");
                                break;
                        }
                        break;
                }
            }

            if (!player1.IsDestroyed)
            {
                Console.WriteLine($"{player1.Name} won");
            }
            else
            {
                Console.WriteLine($"{player2.Name} won");
            }
        }
    }
}
