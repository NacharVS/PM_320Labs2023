public class Peasant : Moveble
{
    public Peasant(Logger logger,string name, double health, int cost, int lvl,
    double maxHp, double speed)
        : base(logger,name, health, cost, lvl, maxHp, speed)
    {
    }
    public void Mining()
    {
        _logger.Log($"Mining...");
    }

    public void Choping()
    {
        _logger.Log("Chopping...");
    }

}
