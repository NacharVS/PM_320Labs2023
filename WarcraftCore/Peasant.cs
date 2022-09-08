namespace WarcraftCore;

public class Peasant : Moveable
{
    public Peasant(int health, string name, int cost, int level, int moveSpeed, ILogger logger) : 
        base(health, name, cost, level, moveSpeed, logger)
    {
    }

    public void Mine() { }

    public void Chop() { }
    

    public override void Move()
    {
        throw new NotImplementedException();
    }
}