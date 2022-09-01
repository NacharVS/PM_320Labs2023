namespace Warcraft.Core;

public class Peasant : Movable
{
    public Peasant(int health, int cost, string name, int level, int speed) :
        base(health, cost, name, level, speed)
    {
    }

    public override void Move()
    {
    }

    public void Mine()
    {
    }

    public void Chop()
    {
    }
}