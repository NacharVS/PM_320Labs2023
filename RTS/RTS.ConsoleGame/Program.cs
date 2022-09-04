using System;
using RTS.Core;


Unit unit1 = new Mage(100, 16, "Экстрасенс Боря", 5,8,35, 
    2100, 0,10,150);
Unit unit2 = new Footman(130, 12,"Рыцарь Олежа", 4,11,30,2000, 20);

/*
Console.WriteLine($"Здравствуй, путник.\n Тебе нужно выбрать двух персонажей," +
                  $" которые будут сражаться между собой \n Это будет легендарная битва!");
Console.WriteLine($" Кем будет твой первый воин?\n1 - Крестьянин (мирный, трудяга)" +
                  $"\n2 - Башня(отстувует броня)\n3 - Пехотинец(прикольный челик)" +
                  $"\n4 - Маг(имбовый чел, много прикольный заклинаний)\n5 - Дракон(здаровенная ящерица)" +
                  $"\n Введи арабскую цифру желаемого персонажа на клавиатуре");
unit1 = ChooseEntity(Console.ReadLine());
Console.WriteLine(" Кем будет твой второй воин?"+
        $"\n Введи арабскую цифру желаемого персонажа на клавиатуре");
unit2 = ChooseEntity(Console.ReadLine());
}
*/

while (!unit1.IsDestroyed && !unit2.IsDestroyed)
{
    ((Military)unit1).Attack(unit2);
    
    if (unit2.IsDestroyed) 
    {
        Console.WriteLine($"Игрок {unit2.Name} помер");
        break;
    }

    ((Military)unit2).Attack(unit1);
    
    if (unit1.IsDestroyed) Console.WriteLine($"Игрок {unit1.Name} помер");
}

Unit ChooseEntity(string entity)
{
    switch (entity)
    {
        case "1" :
            return new Peasant(100,10,"Петр Петрович", 1, 10);
        case "2" :
            return new GuardTower(180, 15, "Башня слёз", 3, 10, 30, 5000);
        case "3" :
            return new Footman(130, 12,"Рыцарь Олежа", 4,11,30,2000, 20);
        case "4" :
            return new Mage(120, 16, "Экстрасенс Боря", 5,10,35, 
                2100, 0,10,150);
        case "5" :
            return new Dragon(100,10,"Дракоша из Шрека", 10, 50,
                55, 5000, 55, 50, 200);
    }
    return new Peasant(100,10,"Петр Петрович", 1, 10);
}