public abstract class Unit
{
    private string _name;
    private double _health;
    private int _cost;
    private int _lvl;
    private bool _isDestroyed;
    private double _maxHp;

    public delegate void HealthChangedDelegate();

    public event HealthChangedDelegate HealthChangedEvent;
    
    public Unit(string name, double health, int cost, int lvl, double maxHp)
    {
        _name = name;
        _health = health;
        _cost = cost;
        _lvl = lvl;
        _maxHp = maxHp;
    }

    public double GetHealth()
    {
        return _health;
    }

    public void SetHealth(double newHealth)
    {
        _health = newHealth;
        HealthChangedEvent?.Invoke();
        Console.WriteLine($"{_name} have a {_health} hp...");
    }

    public bool GetState()
    {
        return _isDestroyed;
    }

    public void SetState(bool state)
    {
        _isDestroyed = state;
        Console.WriteLine($"{_name} is dead!");
    }

    public double GetMaxHealth()
    {
        return _maxHp;
    }

    public string GetName()
    {
        return _name;
    }
}