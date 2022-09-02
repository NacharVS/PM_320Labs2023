namespace Warcraft.Core;

public abstract class Movable : Unit
{
    public int MoveSpeed { get; protected set; }

    public abstract void Move();

    protected Movable(int health, int cost, string name, int level, int speed)
        : base(health, cost, name, level)
    {
        MoveSpeed = speed;
    }

    public void Slow(int percent)
    {
        MoveSpeed -= MoveSpeed * percent / 100;
    }
}