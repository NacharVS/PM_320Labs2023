namespace Warcraft.Core;

public abstract class Movable : Unit
{
    public int MoveSpeed { get; protected set; }

    public void Move()
    {
        Log("Переместился куда-то");
    }

    protected Movable(IEventLogger logger,int health, int cost, string name, int level, int speed)
        : base(logger, health, cost, name, level)
    {
        MoveSpeed = speed;
    }

    public void Slow(int percent)
    {
        MoveSpeed -= MoveSpeed * Math.Min(percent, 100) / 100;
        Log($"Скорость уменьшена на {percent}%");
    }
}