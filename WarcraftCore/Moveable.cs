namespace WarcraftCore;

public abstract class Moveable : Unit
{
    protected int moveSpeed;

    protected Moveable(int health, string name, int cost, int level, int moveSpeed, ILogger logger) : 
        base(health, name, cost, level, logger)
    {
        this.moveSpeed = moveSpeed;
    }

    public abstract void Move();
    
}