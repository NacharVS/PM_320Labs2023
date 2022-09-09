using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace WarCraft
{
    class Blacksmith : Unit
    {
        public static int ArmorCount = 10;
        public static int WeaponCount = 10;
        public static int BowCount = 5;

        public Blacksmith(string name, int health,
            int cost) : base(name, health, cost)
        {
        }

        public void UpgradeArmor(Military pers)
        {
            pers.Armor += ArmorCount;
        }

        public void UpgradeWeapon(Military pers)
        {
            pers.Damage += WeaponCount;
        }

        public void UpgradeBow(Archer pers)
        {
            pers.ArrowCount += BowCount;
        }

        public string Upgrade(Military player)
        {
            var random = new Random();
            int upgrade = random.Next(1, 4);

            switch (upgrade)
            {
                case 1:
                    UpgradeArmor(player);
                    return $"{player.Name} has upgrade his armor";
                    break;
                case 2:
                    UpgradeWeapon(player);
                    return $"{player.Name} has upgrade his weapon";
                    break;
                case 3:
                    return $"{player.Name} hasn't upgraded anything";
                    break;
            }

            return "";
        }

        public string ArcherUpgrade(Archer player)
        {
            var random = new Random();
            int archerUpgrade = random.Next(1, 3);

            if (player is Archer)
            {
                switch (archerUpgrade)
                {
                    case 1:
                        UpgradeBow(player);
                        return $"Archer has upgraded the bow";
                        break;
                    case 2:
                        return $"Archer hasn't upgraded the bow";
                        break;
                }
            }

            return "";
        }
    }
}
