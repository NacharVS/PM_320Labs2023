// See https://aka.ms/new-console-template for more information
using Labs320;

Unit unit = new Unit("Freddy",30 );
unit.AddToInventory(new Item("Pencil", 1));
unit.AddToInventory(new Item("Erasier", 1));
unit.AddToInventory(new Item("Pen", 5));
MongoDBExamples.ReplaceByName("Freddy", unit);



static void Info(int value)
{
    Console.WriteLine($"Health Value - {value}");
}

static void InfoExtended(int value, int val2)
{
    Console.WriteLine($"Health Value - {value} Max - {val2}");
}

static void Rage()
{
    Console.WriteLine("Rage is activated!");
}

static void Adrenaline()
{
    Console.WriteLine("Opa opa adrenaline!111");
}

