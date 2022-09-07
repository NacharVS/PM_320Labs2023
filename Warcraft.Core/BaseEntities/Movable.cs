namespace Warcraft.Core.BaseEntities;

public abstract class Movable : Unit
{
    public int Speed { get; private protected set; }

    protected Movable(int health, int cost, string? name, int level, int speed)
        : base(health, cost, name, level)
    {
        Speed = speed;
    }

    public abstract void Move();
}