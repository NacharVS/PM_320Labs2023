﻿
public class Fight
{
    public Unit[] Players = new Unit[2];
/*    public int Chronicles = 0;
    public Dictionary<int, string> Fire_list  = new Dictionary<int, string>();*/

    public void Introduction()
    {
    start:

        Console.WriteLine("\nСписок классов:\nSpearman, Mage, Dragon, Peasant, Guard_tower, Archer\n");
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
/*            Console.WriteLine("Желаете ли прокачать героя? ");
            string ans = Console.ReadLine();
            if (ans != null)
            {
                taked_hero = Upgrade(taked_hero);
            }*/

            Players[i] = taked_hero;
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

    //Пересчет списка героев
    public void Recalculation() 
    {

    }

    private Unit Unit_request(string name)
    {
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
            case ("archer" or "Archer"):
                taked_unit = new Archer();
                break;
        }
        Console.WriteLine($"Ваш выбор - {name}!");
/*        Fire_list.Add(Chronicles, );*/

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
            //Нужно придумать способ, каким получится останавливать бой в ничью
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
/*            Chronicles++;*/
        }

/*        Chronicles++;*/
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

    private Unit Upgrade(Unit hero)
    {
        Blacksmith bs = new Blacksmith();
        Console.WriteLine("Выберите одно из улучшений. Полный список возможных улучшений:");
        Console.WriteLine("armour - улучшение брони \n weapon - улучшение оружия \n bow - улучшение лука \n");
        string ans = Console.ReadLine();
        switch (ans)
        {
            case "armour":
                bs.Upgrade_armour(hero);
                break;
/*            case "weapon":
                bs.Upgrade_weapon(hero);
                break;
            case "bow":
                bs.Upgrade_bow(hero);
                break;*/
        }            
        return hero;
    }

/*    private void Upgrading(Unit hero)
    {
        Blacksmith.Upgrade_armour(hero);
    }

    private void Upgrading(Military hero)
    {
        Blacksmith.Upgrade_weapon(hero);
    }

    private void Upgrading(Archer hero)
    {
        Blacksmith.Upgrade_bow(hero);
    }*/
}


