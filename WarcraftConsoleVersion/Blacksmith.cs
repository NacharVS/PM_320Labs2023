public class Blacksmith : Unit
{

    public Blacksmith(int healthPoint, string name, int cost, int level): base(healthPoint, cost, name, level)
    {
    }

    public void UpgradeWeapon()
    {
        int[] upgradeCharacter = new int[Game.character.Count];
        int indexCharacter;
        Console.WriteLine("Choose character(index) for upgrade:");
        for (int i = 0; i < Game.character.Count; i++)
        {
            if (Game.character[i].ToString() == "Archer" || Game.character[i].ToString() == "Military" ||
                Game.character[i].ToString() == "Footman" || Game.character[i].ToString() == "RangeMan" ||
                Game.character[i].ToString() == "Mage" || Game.character[i].ToString() == "Dragon" ||
                Game.character[i].ToString() == "Archer")
            {
                Console.WriteLine((i + 1) + ". " + Game.character[i].name);
                upgradeCharacter[i] = 1;
            }
        }
        for(int i = 0; i < upgradeCharacter.Length; i++)
        {
            Console.WriteLine(upgradeCharacter[i]);
        }

        indexCharacter = (Convert.ToInt32(Console.ReadLine()) - 1);
        while (upgradeCharacter[indexCharacter] != 1)
        {
            indexCharacter = (Convert.ToInt32(Console.ReadLine()) - 1);
            //Game.character[indexCharacter]
        }
        ((Military)Game.character[indexCharacter]).damage = ((Military)Game.character[indexCharacter]).damage + 2;
    }
    public void UpgradeArmor()
    {
        int[] upgradeCharacter = new int[Game.character.Count];
        int indexCharacter;
        Console.WriteLine("Choose character(index) for upgrade:");
        for (int i = 0; i < Game.character.Count; i++)
        {
            if (Game.character[i].ToString() == "Archer" || Game.character[i].ToString() == "Military" ||
                Game.character[i].ToString() == "Footman" || Game.character[i].ToString() == "RangeMan" ||
                Game.character[i].ToString() == "Mage" || Game.character[i].ToString() == "Dragon" ||
                Game.character[i].ToString() == "Archer")
            {
                Console.WriteLine((i + 1) + ". " + Game.character[i].name);
                upgradeCharacter[i] = 1;
            }
        }
        indexCharacter = (Convert.ToInt32(Console.ReadLine()) - 1);
        while (upgradeCharacter[indexCharacter - 1] != 1)
        {
            indexCharacter = (Convert.ToInt32(Console.ReadLine()) - 1);
            //Game.character[indexCharacter]
        }
        ((Military)Game.character[indexCharacter]).armor = ((Military)Game.character[indexCharacter]).armor + 2;
    }
    public void UpgradeBow()
    {
        int[] upgradeCharacter = new int[Game.character.Count];
        int indexCharacter;
        Console.WriteLine("Choose character(index) for upgrade:");
        for (int i = 0; i < Game.character.Count; i++)
        {
            if (Game.character[i].ToString() == "Archer")
            {
                Console.WriteLine((i + 1) + ". " + Game.character[i].name);
                upgradeCharacter[i] = 1;
            }
        }
        indexCharacter = (Convert.ToInt32(Console.ReadLine()) - 1);
        while (upgradeCharacter[indexCharacter] != 1)
        {
            indexCharacter = (Convert.ToInt32(Console.ReadLine()) - 1);
            //Game.character[indexCharacter]
        }
        ((Archer)Game.character[indexCharacter]).arrowCount = ((Archer)Game.character[indexCharacter]).arrowCount + 10;
    }

    public void СomeIn()
    {
        Console.WriteLine("Hello, dear player! Welcome to the " + name);
        Console.WriteLine("Chose what you need: Upgrade Weapon(1), Upgrade Armor(2) or Upgrade Bow(3)");
        string codeUpgrade;
        bool upgradeCheck = false;
        while (!upgradeCheck)
        {
            codeUpgrade = Console.ReadLine();
            switch (codeUpgrade)
            {
                case "1":
                    UpgradeWeapon();
                    upgradeCheck = true;
                    break;
                case "2":
                    UpgradeArmor();
                    upgradeCheck = true;
                    break;
                case "3":
                    UpgradeBow();
                    upgradeCheck = true;
                    break;
            }

            if (!upgradeCheck)
            {
                Console.WriteLine("Unknown code...");
            }
        }
    }
}