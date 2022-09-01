namespace Warcraft.Core;

public abstract class Unit
{
    public int Health { get; private set; }
    public int MaxHealth { get; }
    public int Cost { get; private set; }
    public string Name { get; private set; }
    public int Level { get; private set; }
    public bool IsDestroyed { get; private set; }


    protected Unit(int health, int cost, string name, int level)
    {
        MaxHealth = health;
        Health = health;
        Cost = cost;
        Name = name;
        Level = level;
    }

    public virtual void GetDamage(int damage)
    {
        if (IsDestroyed)
            return;
        
        if (Health <= damage)
        {
            Health = 0;
            IsDestroyed = true;
            return;
        }

        Health -= damage;
    }

    public void GetHealed()
    {
        if (IsDestroyed)
            return;

        Health = Math.Min(MaxHealth, ++Health);
    }
}