using RTS.Core.BaseEntities;

namespace RTS.Core.Units;

public class Peasant : Movable
{
    public Peasant(int health, int cost, string? name, int level, int speed) 
        : base(health, cost, name, level, speed)
    {
        
    }

    public void Mining()
    {
        Console.WriteLine("Peasant is mining..");
        Thread.Sleep(3000);
        Console.WriteLine("Mining is done!");
    }

    public void Chopping()
    {
        Console.WriteLine("Peasant is chopping");
        Thread.Sleep(3000);
        Console.WriteLine("Chopping is done!");
    }
}