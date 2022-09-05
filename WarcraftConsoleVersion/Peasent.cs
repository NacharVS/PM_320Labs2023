public class Peasent : Moveble
{
    public int damage = 0;
    public Peasent(int healthPoint, int cost, string name, int level, int speed) :
        base(healthPoint, cost, name, level, speed)
    {
    }
    public override int getAttackSpeed()
    {
        return 10;
    }
    public override void Mining()
    {
        Console.WriteLine(name + ".Mining");
    }
    public override void Choping()
    {
        Console.WriteLine(name + ".Choping");
    }
}