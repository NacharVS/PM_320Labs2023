namespace WarcraftCore;

public abstract class Unit
{
    protected int health;
    protected int maxHealth;
    protected string name;
    protected int cost;
    protected int level;

    protected bool isStunned;
    protected bool isDestroyed;

    public delegate void HealthChangedDelegate();

    public event HealthChangedDelegate HealthChangedEvent;

    protected Unit(int health, string name, int cost, int level)
    {
        this.health = health;
        maxHealth = health;
        this.name = name;
        this.cost = cost;
        this.level = level;
        
    }

    public virtual void GetHit(int damage)
    {
        health -= damage;
        HealthChangedEvent?.Invoke();
        
        if (health <= 0)
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        isDestroyed = true;
    }

    public void SetHealthPoint(int healPoint)
    {
        if (isDestroyed)
            return;
        
        if (CanHeal(healPoint))
        {
            health += healPoint;
        }
    }

    private bool CanHeal(int healPoint)
    {
        return health + healPoint <= maxHealth;
    }

    public bool IsDestroyed()
    {
        return isDestroyed;
    }

    public string GetName()
    {
        return name;
    }

    public void GetStunned()
    {
        isStunned = true;
    }
}