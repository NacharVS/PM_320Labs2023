namespace WarcraftCore;

public abstract class Moveable : Unit
{
    protected int moveSpeed;

    protected Moveable(int health, string name, int cost, int level, int moveSpeed) : 
        base(health, name, cost, level)
    {
        this.moveSpeed = moveSpeed;
    }

    public abstract void Move();
    
}