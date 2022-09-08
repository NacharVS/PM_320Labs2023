using System;

class Program
{
    static void Main()
    {

        Console.WriteLine("/------------------/");
        Console.WriteLine("Новый тест");
        Console.WriteLine();

 /*       Peasant Serg = new Peasant();
        Console.WriteLine($"Накопали {Serg.Mining()} булыжника");*/

        Guard_tower Kings_yard = new Guard_tower();
        Console.WriteLine(Kings_yard.Attack());

        Unit[] units = new Unit[3];
        units[0] = Kings_yard;
        Console.WriteLine(units[0].Defence);

        Fight test_fight = new Fight();
        test_fight.Introduction();

        Archer archer = new Archer();
        Console.WriteLine(archer.Radius);

        Kings_yard.Taking_damage_event += Health_newers(4, "dsdsd");
    }

    static void Health_newers(double real_loss, string name)
    {
        Console.WriteLine($"{name} получает урон, равный {real_loss}!");
    }
}


