// See https://aka.ms/new-console-template for more information
using Labs320;

Unit unit1 = new Unit("Bob", 33, 123456);
Unit unit2 = new Unit("Jimmy", 55);

MongoDBExamples.AddToDataBase(unit2);

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

