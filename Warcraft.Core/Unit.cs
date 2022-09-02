namespace Warcraft.Core;

public abstract class Unit
{
    public int Health { get; private set; }
    public int MaxHealth { get; }
    public int Cost { get; private set; }
    public string Name { get; private set; }
    public int Level { get; private set; }
    public bool IsDestroyed { get; private set; }

    private readonly IEventLogger _logger;

    public event EventHandler? OnHpChange; 


    protected Unit(IEventLogger logger, int health, int cost, string name, int level)
    {
        _logger = logger;
        MaxHealth = health;
        Health = health;
        Cost = cost;
        Name = name;
        Level = level;
        
        OnHpChange += CheckHp;
    }

    public virtual void Hit(int damage)
    {
        if (IsDestroyed)
        {
            Log("Уже мертв и не может получить урон");
            return;
        }
        
        Health -= damage;
        OnHpChange?.Invoke(this, new HealthPointEventArgs(Health + damage, Health));
    }

    public void GetHealed()
    {
        if (IsDestroyed)
        {
            Log("Мертв и не может быть вылечен");
            return;
        }

        Health = Math.Min(MaxHealth, Health + 1);
        OnHpChange?.Invoke(this, new HealthPointEventArgs(Health - 1, Health));
    }

    protected void Log(string message)
    {
        _logger.LogInfo(this, message);
    }
    
    private void CheckHp(object? sender, EventArgs args)
    {
        if (Health <= 0)
        {
            Health = 0;
            IsDestroyed = true;
            Log("Пал смертью храбрых");
        }
        else
        {
            if (args is HealthPointEventArgs healthArgs)
                Log($"Здоровье изменено ({healthArgs.PreviousHealth} -> {healthArgs.CurrentHealth})");
        }
    }
}