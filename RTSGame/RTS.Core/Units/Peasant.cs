using RTS.Core.BaseEntities;
using RTS.Core.Logger;

namespace RTS.Core.Units;

public class Peasant : Movable
{
    public Peasant(int health, int cost, string? name, int level, int speed, ILogger logger) 
        : base(health, cost, name, level, speed, logger)
    {
        
    }

    public void Mining()
    {
        Logger.Log(LogMessageType.Info, "Peasant is mining..");
        Thread.Sleep(3000);
        Logger.Log(LogMessageType.Info, "Mining is done!");
    }

    public void Chopping()
    {
        Logger.Log(LogMessageType.Info, "Peasant is chopping");
        Thread.Sleep(3000);
        Logger.Log(LogMessageType.Info, "Chopping is done!");
    }
}