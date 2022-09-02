namespace Warcraft.Core;

public abstract class Unit
{
    public int Health { get; private set; }
    public int MaxHealth { get; }
    public int Cost { get; private set; }
    public string Name { get; private set; }
    public int Level { get; private set; }
    public bool IsDestroyed { get; private set; }

    public event EventHandler? OnHpChange; 


    protected Unit(int health, int cost, string name, int level)
    {
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
            return;
        
        Health -= damage;
        OnHpChange?.Invoke(this, new HealthPointEventArgs(Health + damage, Health));
    }

    public void GetHealed()
    {
        if (IsDestroyed)
            return;

        Health = Math.Min(MaxHealth, Health + 1);
        OnHpChange?.Invoke(this, new HealthPointEventArgs(Health - 1, Health));
    }
    
    private void CheckHp(object? sender, EventArgs args)
    {
        if (Health < 0)
        {
            Health = 0;
            IsDestroyed = true;
        }
    }
}