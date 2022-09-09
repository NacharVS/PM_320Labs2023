using WarcraftGameCore;

namespace WarcraftGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            Logger logger = new ConsoleLogger();

            //-------Players-------
            Footman footman = new Footman(logger, "Footman - 1");
            Mage mage = new Mage(logger, "Mage - 2");
            Archer archer = new Archer(logger, "Archer - 1");
            Blacksmith blacksmith = new Blacksmith(logger, "Blacksmith - 1");

            var players = new List<Military> { footman, mage, archer };

            //-------Game---------
            Military firstPlayer;
            Military secondPlayer;

            while (players.Count() != 1)
            {
                firstPlayer = players[random.Next(0, players.Count())];
                secondPlayer = players[random.Next(0, players.Count())];

                firstPlayer.Attack(secondPlayer);

                if (secondPlayer.CheckDied())
                {
                    players.Remove(secondPlayer);
                }
            }

            Console.WriteLine($"{players[0].GetName()} WIN!!!!!");
        }
    }
}