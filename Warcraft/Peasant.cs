class Peasant : Moveble
{
    public Peasant(int health, int cost, string name, int speed)
            : base(health, cost, name, speed) { }

    public void Mining()
    {
        if (isStun)
        {
            Console.WriteLine($"{name} scip this move because he's stunned");
            return;
        }

        Console.WriteLine("I'm mining now");
    }

    public void Choping()
    {
        if (isStun)
        {
            Console.WriteLine($"{name} scip this move because he's stunned");
            return;
        }

        Console.WriteLine("I'm choping now");
    }
}

