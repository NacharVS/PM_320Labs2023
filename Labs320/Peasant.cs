class Peasant : Moveble
{
    public Peasant(int health, int cost, string name, int speed) : base(health, cost, name, speed)
    {
    }
    public void Mining()
    {
        Console.WriteLine("I'm mining now");
    }

    public void Choping()
    {
        Console.WriteLine("I'm choping now");
    }

    public override void Move()
    {
        Console.WriteLine("I'm move to nahuy");
    }
}

