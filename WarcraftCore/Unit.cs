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

    protected ILogger logger;

    public delegate void HealthChangedDelegate();

    public delegate void AfterHealthChangedDelegate(int previousHealth, int afterChangeHealth);

    public delegate void DeathDelegate();

    public event HealthChangedDelegate HealthChangedEvent;
    public event DeathDelegate DeathEvent;
    public event AfterHealthChangedDelegate AfterHealthChangedEvent;

    protected Unit(int health, string name, int cost, int level, ILogger logger)
    {
        this.health = health;
        maxHealth = health;
        this.name = name;
        this.cost = cost;
        this.level = level;
        this.logger = logger;

        DeathEvent += Destroy;
        AfterHealthChangedEvent += HealthChanged;
    }

    public virtual void GetHit(int damage)
    {
        health -= damage;
        AfterHealthChangedEvent?.Invoke(health + damage, health);
    }

    public void Destroy()
    {
        isDestroyed = true;
        logger.Log($"{GetName()} умер");
    }

    public void GetHeal(int healPoint)
    {
        if (CanHeal(healPoint))
        {
            health += healPoint;
        }
    }

    private bool CanHeal(int healPoint)
    {
        return health + healPoint <= maxHealth;
    }

    private void HealthChanged(int previousHealth, int afterChangeHealth)
    {
        if (health <= 0)
        {
            DeathEvent?.Invoke();
        }
        else
        {
            logger.Log($"Здоровье {GetName()} изменилось c {previousHealth} на {afterChangeHealth}");
        }
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