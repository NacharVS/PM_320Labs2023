using RTS.Core.EventArgs;
using RTS.Core.Logger;

namespace RTS.Core.BaseEntities;

public abstract class Unit
{
    public ILogger Logger { get; set; }
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

    protected Unit(int health, int cost, string? name, int level, ILogger logger)
    {
        Health = health;
        Cost = cost;
        Name = name;
        Level = level;
        MaxHealth = health;
        Logger = logger;
        
        OnGetDamage += delegate(Unit _, HitArgs args)
        {
            if (IsDestroyed)
            {
                Logger.Log(LogMessageType.Warning, "Unit is already destroyed");
                return;
            }
            
            Health -= args.Damage;
            Logger.Log(LogMessageType.Info, args.Damage >= 0 
                ? $"Unit \"{Name}\" gets {args.Damage} points of damage." 
                : $"Unit \"{Name}\" gets {args.Damage} points of heal.");
            
            if (Health <= 0)
                OnDeath?.Invoke(this, new DeathArgs());
        };

        OnDeath += delegate
        {
            IsDestroyed = true;
            Logger.Log(LogMessageType.Info, $"Unit \"{Name}\" is destroyed");
        };
    }

    public virtual void GetDamage(int damage)
    {
        OnGetDamage?.Invoke(this, new HitArgs(damage, Health));
    }
}