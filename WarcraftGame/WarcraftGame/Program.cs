using WarcraftGameCore;

namespace WarcraftGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Footman footman = new Footman("Footman - 1");
            Mage mage = new Mage("Mage - 2");

            while(!footman.CheckDied() && !mage.CheckDied())
            {
                footman.Attack(mage);
                mage.Attack(footman);
            }

            Archer archer = new Archer("Archer - 1");
            Blacksmith blacksmith = new Blacksmith("Blacksmith - 1");

            var players = new List<Unit> { footman, mage, archer };
            blacksmith.UpgradeBow(players);
            blacksmith.UpgradeArmor(players);
        }
    }
}