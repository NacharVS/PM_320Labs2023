namespace Warcraft.Core;

public class Peasant : Movable
{
    public Peasant(IEventLogger logger, int health, int cost, string name,
        int level, int speed) :
        base(logger, health, cost, name, level, speed)
    {
    }

    public void Mine()
    {
        Log("Накопал руды");
    }

    public void Chop()
    {
        Log("Добыл дерева");
    }
}