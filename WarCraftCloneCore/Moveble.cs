public abstract class Moveble : Unit
{
    private double _speed;

    public Moveble(string name, double health, int cost, int lvl,
                                        double maxHp, double speed)
    : base(name,  health,  cost,  lvl,  maxHp)
    {
        _speed = speed;
    }

    public void Move()
    {
        if (GetState() == false)
        {
            return;
        }
        Console.WriteLine($"Move with {_speed} speed...");
    }

    public double GetSpeed()
    {
        return _speed;
    }
}