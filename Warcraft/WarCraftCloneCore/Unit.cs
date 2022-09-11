public abstract class Unit
{
    private string _name;
    private double _health;
    private int _cost;
    private int _lvl;
    private bool _isDestroyed;
    private double _maxHp;
    protected Logger _logger;
    private int _healDebuffPeriod;
    public int HealDebuffPeriod
    {
        get { return +_healDebuffPeriod; }
        set
        {
            if(value < 0)
            {
                _healDebuffPeriod = 0;
            }
            _healDebuffPeriod = value;
        }
    }

    public delegate void HealthChangedDelegate(double healthChange);

    public event HealthChangedDelegate HealthChangedEvent;

    public Unit(Logger logger, string name, double health, int cost, int lvl, double maxHp)
    {
        _name = name;
        _health = health;
        _cost = cost;
        _lvl = lvl;
        _maxHp = maxHp;
        _logger = logger; 
        
        HealthChangedEvent += CheckHealthChange;
    }

    public double GetHealth()
    {
        return _health;
    }

    public void SetHealth(double newHealth)
    {
        var currentHealth = _health;
        _health = newHealth;
        HealthChangedEvent?.Invoke(newHealth - currentHealth);
        HealDebuffPeriod = HealDebuffPeriod - 1;
        
        _logger.Log($"{_name} have {_health} health.");
    }

    public bool GetState()
    {
        return _isDestroyed;
    }

    public void CheckHealthChange(double healthChange)
    {
        if (healthChange > 0)
        {
            _logger.Log($"{this._name} was healed {healthChange}!");
        }
        else
        {
            _logger.Log($"{this._name} was damaged {healthChange}!");
        }
    }

    public void SetState(bool state)
    {
        _isDestroyed = state;
        _logger.Log($"{_name} is dead!");
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