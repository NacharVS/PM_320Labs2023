using RTS.Core.Logger;

namespace RTS.Core.BaseEntities;

public abstract class Movable : Unit
{
    public int Speed { get; private protected set; }

    protected Movable(int health, int cost, string? name, int level, int speed, ILogger logger) 
        : base(health, cost, name, level, logger)
    {
        Speed = speed;
    }

    public void Move() {}
}