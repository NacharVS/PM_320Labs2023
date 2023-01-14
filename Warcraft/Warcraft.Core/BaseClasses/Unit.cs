using Warcraft.Core.Effects;
using Warcraft.Core.Events;
using Warcraft.Core.Spells;

namespace Warcraft.Core.BaseClasses;

public abstract class Unit
{
    private object _lockObject = "";
    public int Health { get; private set; }
    public int MaxHealth { get; }
    public int Cost { get; private set; }
    public string Name { get; private set; }
    public int Level { get; private set; }
    public bool IsDestroyed { get; private set; }

    public List<Effect> ActiveEffects { get; private set; }

    private readonly IEventLogger _logger;

    public event EventHandler? AfterHpChange;
    public event EventHandler? OnDeath;
    public event EventHandler? OnEffectTick;


    protected Unit(IEventLogger logger, int health, int cost, string name,
        int level)
    {
        _logger = logger;
        MaxHealth = health;
        Health = health;
        Cost = cost;
        Name = name;
        Level = level;
        ActiveEffects = new List<Effect>();

        AfterHpChange += CheckHp;
        OnEffectTick += ProcEffects;
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
        OnEffectTick?.Invoke(this, EventArgs.Empty);
    }

    public void AddEffect(Effect effect)
    {
        lock (_lockObject)
        {
            var existingEffect =
                ActiveEffects.FirstOrDefault(x => x.Name == effect.Name);
            if (existingEffect is not null)
            {
                existingEffect.Duration += effect.Duration;
                return;
            }

            ActiveEffects.Add(effect);
            Log($"Получил эффект {effect.Name}");
        }
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
        OnEffectTick?.Invoke(this, EventArgs.Empty);
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

    private void ProcEffects(object? sender, EventArgs args)
    {
        if (IsDestroyed)
            return;

        lock (_lockObject)
        {
            foreach (var effect in ActiveEffects)
            {
                if (effect.Duration <= 0)
                {
                    ActiveEffects.Remove(effect);
                    Log($"Эффект {effect.Name} снят");
                    return;
                }

                Health -= effect.Damage;
                AfterHpChange?.Invoke(this,
                    new HealthPointEventArgs(Health + effect.Damage, Health));
                effect.Duration--;
                Log(effect.LogMessage);
            }
        }
    }
}