abstract class Moveble : Unit 
{
    public Moveble(int health, int cost, string name, int speed) : base(health, cost, name)
    {
        this.speed = speed;
    }

    protected int speed;

    public void Move() 
    {
        Console.WriteLine("I'm move");
    }
}

