using System;

class Program
{
    static void Main()
    {
        Spearman Tom = new Spearman();
        Spearman Bob = new Spearman();
        Tom.Real_health = 30;
        Bob.Real_health = 50;

        Console.Write(Tom.Real_health);
        Console.Write(" " + Bob.Real_health);

        Tom.Real_health = 100;
        Tom.Taking_damage(20);
        Bob.Taking_damage(20);

        Console.WriteLine();
        Console.Write(Tom.Real_health);
        Console.Write(" " + Bob.Real_health);

        Console.WriteLine();
        Tom.Berserker();
        Console.WriteLine(Tom.Damage);

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


    }
}
