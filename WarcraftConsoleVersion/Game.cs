public class Game
{
    private string name;

    public Game(string name)
    {
        this.name = name;
    }

    internal static Unit AddUnit(string nameUnit, Unit unit)
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
                    unit = new GuardTowers(600, 120, nameUnit, 1, 800, 90, 3);
                    createCheck = true;
                    break;
                case "2":
                    unit = new Peasent(220, 75, nameUnit, 1, 99999);
                    createCheck = true;
                    break;
                case "3":
                    unit = new Footman(420, 135, nameUnit, 1, 1, 13, 1, 2);
                    createCheck = true;
                    break;
                case "4":
                    unit = new Mage(550, 425, nameUnit, 1, 1, 27, 2, 2, 60, 285);
                    createCheck = true;
                    break;
                case "5":
                    unit = new Dragon(2200, 745, nameUnit, 1, 1, 64, 2, 6, 300, 600);
                    createCheck = true;
                    break;
                case "6":
                    unit = new Archer(550, 425, nameUnit, 1, 1, 27, 2, 2, 60);
                    createCheck = true;
                    break;
            }

            if (!createCheck)
            {
                Console.WriteLine("Unknown code...");
            }
        }
        return unit;
    }

    public void GameStart(Unit oneCharachter, Unit twoCharachter)
    {
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