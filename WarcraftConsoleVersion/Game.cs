public class Game
{
    private string name;
    public static List<Unit> character = new List<Unit>();
    public Game(string name)
    {
        this.name = name;
    }

    public static int amountCharacter()
    {
        return character.Count();
    }

    public static void getAllCharacters()
    {
        for(int i = 0; i < character.Count; i++)
        {
            Console.WriteLine((1+i) + "." + character[i] + ", name: " + character[i].name);
        }
    }
    public static void AddUnit(string nameUnit)
    {
        string codeUnit;
        bool createCheck = false;
        while (!createCheck)
        {
            Console.WriteLine("\nWrite code unit: ");
            codeUnit = Console.ReadLine();
            switch (codeUnit)
            {
                case "1":
                    GuardTowers guardTowers = new(600, 120, nameUnit, 1, 800, 90, 3);
                    character.Add(guardTowers);
                    createCheck = true;
                    break;
                case "2":
                    Peasent peasent = new(220, 75, nameUnit, 1, 99999);
                    character.Add(peasent);
                    createCheck = true;
                    break;
                case "3":
                    Footman footman = new (420, 135, nameUnit, 1, 1, 13, 1, 2);
                    character.Add(footman);
                    createCheck = true;
                    break;
                case "4":
                    Mage mage = new(550, 425, nameUnit, 1, 1, 27, 2, 2, 60, 285);
                    character.Add(mage);
                    createCheck = true;
                    break;
                case "5":
                    Dragon dragon = new (2200, 745, nameUnit, 1, 1, 64, 2, 6, 300, 600);
                    character.Add(dragon);
                    createCheck = true;
                    break;
                case "6":
                    Archer archer= new(550, 425, nameUnit, 1, 1, 27, 2, 2, 60);
                    character.Add(archer);
                    createCheck = true;
                    break;
            }

            if (!createCheck)
            {
                Console.WriteLine("Unknown code...");
            }
        }
    }

    public void GameStart(int one, int two)
    {
        if(one != two)
        {
            Unit oneCharachter = character[one];
            Unit twoCharachter = character[two];
            Thread myThread = new Thread(Fight);

            myThread.Start();

            while (oneCharachter.alive && twoCharachter.alive)
            {
                Console.WriteLine(twoCharachter.name + " attack " + oneCharachter.name +
                    ", left " + oneCharachter.healthPoint);
                twoCharachter.Attack(oneCharachter);
                Thread.Sleep(twoCharachter.getAttackSpeed() * 1000);

            }

            void Fight()
            {
                while (oneCharachter.alive && twoCharachter.alive)
                {
                    Console.WriteLine(oneCharachter.name + " attack " + twoCharachter.name +
                        ", left " + twoCharachter.healthPoint);
                    oneCharachter.Attack(twoCharachter);
                    Thread.Sleep(oneCharachter.getAttackSpeed() * 1000);
                }
            }

            if (oneCharachter.alive)
            {
                Console.WriteLine(oneCharachter.name + " kill " + twoCharachter.name);
            }
            else
            {
                Console.WriteLine(twoCharachter.name + " kill " + oneCharachter.name);
            }
        }
    }

    public static void AddCharaters()
    {
        string nameUnit = "none";
        while (nameUnit != "")
        {
            Console.WriteLine("\nWrite name " + (Game.amountCharacter() + 1) + " character:");
            nameUnit = Console.ReadLine();
            if (nameUnit != "")
            {
                Game.AddUnit(nameUnit);
            }
        }
    }
}