using WarcraftCore;

namespace WarcraftConsole;

public static class Program
{
    public static void Main(string[] args)
    {
        ConsoleLogger logger = new ConsoleLogger();
        int tickrate = 1;
        
        Footman f1 = new Footman(100, "Axe", 10, 0, 10, 15, 3, 10, logger);
        Mage m1 = new Mage(100, "Maga", 10, 0, 15, 3, 2, 3, 2, 100, logger);

        List<Unit> units = new List<Unit> { f1, m1 };

        Blacksmith blacksmith = new Blacksmith(units, logger, 5);
        
        Random rand = new Random(); 

        while (!f1.IsDestroyed() && !m1.IsDestroyed())
        {
            int chanceToUpgradeBlacksmith = rand.Next(1, 100);
            
            // Blacksmith can upgrade weapons only after a certain number of moves
            if (chanceToUpgradeBlacksmith < 33)
                blacksmith.UpgradeArmor(tickrate);
            else if (chanceToUpgradeBlacksmith < 66)
                blacksmith.UpgradeWeapon(tickrate);
            else if (chanceToUpgradeBlacksmith > 66)
                blacksmith.UpgradeBow(tickrate);
            
            
            if (tickrate % f1.GetAttackSpeed() == 0)
            {
                f1.Attack(m1);            
            }

            if (tickrate % m1.GetAttackSpeed() == 0)
            {
                m1.Attack(f1);   
            }
            ++tickrate;
        }

        string winnerName = f1.IsDestroyed() ? m1.GetName() : f1.GetName();
        Console.WriteLine($"Win {winnerName}");
    }
}

