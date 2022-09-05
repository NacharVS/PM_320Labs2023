using RTS.Core.EventArgs;

namespace RTS.Core.BaseEntities;

public abstract class Unit
{
    public int Health { get; private protected set; }
    public int Cost { get; private protected set; }
    public string? Name { get; private protected set; }
    public int Level { get; private protected set; }
    private protected readonly int MaxHealth;
    public bool IsDestroyed { get; private protected set; }

    public delegate void HitHandler(Unit sender, HitArgs args);

    public delegate void DeathHandler(Unit sender, DeathArgs args);

    public event HitHandler? OnGetDamage;
    public event DeathHandler? OnDeath;

    protected Unit(int health, int cost, string? name, int level)
    {
        Health = health;
        Cost = cost;
        Name = name;
        Level = level;
        MaxHealth = health;
        
        OnGetDamage += delegate(Unit _, HitArgs args)
        {
            if (IsDestroyed)
            {
                Console.WriteLine("Unit is already destroyed");
                return;
            }
            
            Health -= args.Damage;
            if (Health <= 0)
                OnDeath?.Invoke(this, new DeathArgs());
        };

        OnDeath += delegate
        {
            IsDestroyed = true;
            Console.WriteLine($"Unit \" {Name} \" is destroyed");
        };
    }

    public void GetDamage(int damage)
    {
        OnGetDamage?.Invoke(this, new HitArgs(damage, Health));
    }

    /// <summary>
    /// Raise hit event from inherited class
    /// </summary>
    private protected void RaiseOnHitEvent(Unit sender, HitArgs args)
    {
        OnGetDamage?.Invoke(sender, args);
    }

    /// <summary>
    /// Raise death event from inherited class
    /// </summary>
    private protected void RaiseOnDeathEvent(Unit sender, DeathArgs args)
    {
        OnDeath?.Invoke(sender, args);
    }
}