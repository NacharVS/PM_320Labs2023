public abstract class Moveble : Unit
{
    private double _speed;

    public Moveble(Logger logger, string name, double health, int cost, int lvl,
                                        double maxHp, double speed)
    : base(logger, name,  health,  cost,  lvl,  maxHp)
    {
        _speed = speed;
    }

    public void Move()
    {
        if (GetState())
        {
            return;
        }
        _logger.Log($"Move with {_speed} speed...");
    }

    public double GetSpeed()
    {
        return _speed;
    }
}