
public class Fight
{
    public Unit[] Players = new Unit[2];

    public void Introduction()
    {
        StringHelper stringHelper = new StringHelper();
    start:

        Console.WriteLine("\nСписок классов:\nSpearman, Mage, Dragon, Peasant, Guard_tower\n");
        int honesty = 2;
        for (int i = 0; i < 2; i++)
        {
            Console.Write($"Выберите сторону {i + 1} из представленных классов: ");
            string name = Console.ReadLine();
            Unit taked_hero = Unit_request(name);
            if (taked_hero == null)
            {
                honesty = Honesty_cheking();
                break;
            }
            Players[i] = taked_hero;
            taked_hero.Event_HealthChanged = stringHelper.GetDamage;
        }

        if (honesty == 1)
        {
            Players = new Unit[2];
            goto start;
        }
        else if (honesty == 2)
        {
            Name_checking();
            Battle();
        }

        Console.WriteLine("\nДо свидания!");
    }

    private Unit Unit_request(string name)
    {
        StringHelper stringHelper = new StringHelper();
        Spearman spearman = new Spearman();
        spearman.Event_Berserk = stringHelper.Berserk;
        Unit taked_unit = null;
        switch (name)
        {
            case ("spearman" or "Spearman"):
                taked_unit = new Spearman();
                break;
            case ("dragon" or "Dragon"):
                taked_unit = new Dragon();
                break;
            case ("mage" or "Mage"):
                taked_unit = new Mage();
                break;
            case ("peasant" or "Peasant"):
                taked_unit = new Peasant();
                break;
            case ("guardtower" or "Guardtower"):
                taked_unit = new Guard_tower();
                break;
        }
        Console.WriteLine($"Ваш выбор - {name}!");

        return taked_unit;
    }

    private void Battle()
    {
        Console.WriteLine("\n\n\nБитва начинается. Вкус крови и булата привлечет стаи стервятников...\n");
        int i = 0;
        while (Players[0].Real_health > 0 && Players[1].Real_health > 0)
        {
            if (i == 0)
            {
                double first_loss = Players[0].Step();
                Players[1].Taking_damage(first_loss);
                i++;
            }
            else
            {
                double second_loss = Players[1].Step();
                Players[0].Taking_damage(second_loss);
                i--;
            }
            Console.WriteLine();
        }
        


        if (Players[0].Real_health < 0)
        {
            Console.WriteLine($"{Players[1].Name} побеждает!");
        }
        else if (Players[1].Real_health < 0)
        {
            Console.WriteLine($"{Players[0].Name} побеждает!");
        }
        else
        {
            Console.WriteLine("У нас нет победителя!");
        }
    }

    private int Honesty_cheking()
    {
        Console.WriteLine("Вы ввели неизвестного доселе юнита... попробуете снова? (Yes/No)");
        string answer = Console.ReadLine();
        if (answer == "yes" || answer == "Yes")
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    private void Name_checking()
    {
        if (Players[0].Name == Players[1].Name)
        {
            string nick = Players[0].Name;
            Players[0].Name = ($"{nick} " + $"{1}");
            Players[1].Name = ($"{nick} " + $"{2}");
        }
    }
}


