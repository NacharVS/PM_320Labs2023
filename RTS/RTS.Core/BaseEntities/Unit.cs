using System.ComponentModel;
using System.Runtime.CompilerServices;
using RTS.Core.Annotations;

public abstract class Unit
{
    private int _health;
    public int Health
    {
        get { return _health; }
        internal set
        {
            _health = value;
        }
    }

    public int Cost { get; private protected set; }
    public string? Name { get; private protected set; }
    public int Level { get; private protected set; }
    private protected readonly int MaxHealth;
    public bool IsDestroyed { get; private protected set; }

    protected Unit(int health, int cost, string? name, int level)
    {
        Health = health;
        Cost = cost;
        Name = name;
        Level = level;
        MaxHealth = health;
    }

    public void CheckIsDestroyed()
    {
        if (Health <= 0) IsDestroyed = true;
    }
    public virtual void DealingDamage(ref Unit entity)
    {
        Health -= ((Military)entity).Damage;
    }

}