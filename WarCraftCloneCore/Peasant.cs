public class Peasant : Moveble
{
    public Peasant(string name, double health, int cost, int lvl,
    double maxHp, double speed)
        : base(name, health, cost, lvl, maxHp, speed)
    {
    }
    public void Mining()
    {
        Console.WriteLine($"Mining...");
    }

    public void Choping()
    {
        Console.WriteLine("Chopping...");
    }

}
