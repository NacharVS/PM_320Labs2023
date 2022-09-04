using RTS.Core.BaseEntities;

namespace RTS.ConsoleGame;

public class UnitWrapper
{
    public Military Entity { get; set; }
    public List<Military> Units { get; set; }

    public UnitWrapper(Military entity, List<Military> units)
    {
        Entity = entity;
        Units = units;
    }

    public void Run(object? state)
    {
        Random rnd = new Random();
        while (!Entity.IsDestroyed)
        {
            Unit target;
            while ((target = Units[rnd.Next(0, Units.Count)]) != Entity)
            {
                Entity.Attack(target);
            }
        }
    }
}