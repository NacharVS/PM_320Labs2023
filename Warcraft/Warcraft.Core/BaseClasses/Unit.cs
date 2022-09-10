using Warcraft.Core.Events;

namespace Warcraft.Core.BaseClasses;

public abstract class Unit
{
    public int Health { get; private set; }
    public int MaxHealth { get; }
    public int Cost { get; private set; }
    public string Name { get; private set; }
    public int Level { get; private set; }
    public bool IsDestroyed { get; private set; }

    private readonly IEventLogger _logger;

    public event EventHandler? AfterHpChange;
    public event EventHandler? OnDeath;


    protected Unit(IEventLogger logger, int health, int cost, string name,
        int level)
    {
        _logger = logger;
        MaxHealth = health;
        Health = health;
        Cost = cost;
        Name = name;
        Level = level;

        AfterHpChange += CheckHp;
    }

    internal virtual void Hit(int damage)
    {
        if (IsDestroyed)
        {
            Log("Уже мертв и не может получить урон");
            return;
        }

        Health -= damage;
        AfterHpChange?.Invoke(this,
            new HealthPointEventArgs(Health + damage, Health));
    }

    public void GetHealed(int value)
    {
        if (IsDestroyed)
        {
            Log("Мертв и не может быть вылечен");
            return;
        }

        Health = Math.Min(MaxHealth, Health + value);
        AfterHpChange?.Invoke(this,
            new HealthPointEventArgs(Health - value, Health));
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
            OnDeath?.Invoke(this, new DeathEventArgs());
            Log("Пал смертью храбрых");
        }
        else
        {
            if (args is HealthPointEventArgs healthArgs)
                Log(
                    $"Здоровье изменено ({healthArgs.PreviousHealth} -> {healthArgs.CurrentHealth})");
        }
    }
}