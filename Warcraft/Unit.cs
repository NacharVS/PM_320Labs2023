abstract class Unit
{
    public Unit(int health, int cost, string name)
    {
        this.health = health;
        this.maxHealth = health;
        this.cost = cost;
        this.name = name;
        this.lvl = 0;
        this.isDestroyed = false;
        this.countMovesToFire = 0;
        this.countMovesToFreeze = 0;
        Units.units.Add(this);
        HealthChangedEvent += DamageInfo;
        HealthChangedEvent += HealInfo;
        HealthChangedEvent += FireDamageInfo;
        HealthChangedEvent += FreezeDamageInfo;

        OnDeathEvent += delegate()
        {
            isDestroyed = true;
            Console.WriteLine($"{name} is dead");
            Console.WriteLine("Game over");
        };

        OnStunEvent += delegate()
        {
            Console.WriteLine($"{name} is stunned on 5 seconds");
            Thread.Sleep(5000);
        };
    }
    
    protected int health;
    protected int cost;
    protected string name;
    protected bool isDestroyed;
    protected int lvl;
    protected int maxHealth;
    protected int countMovesToFire;
    protected int damageByFire;
    protected int countMovesToFreeze;
    protected int damageByFreeze;

    public delegate void HealthChangedDelegate(int value);
    public event HealthChangedDelegate HealthChangedEvent;

    public delegate void OnDeathDelegate();
    public event OnDeathDelegate OnDeathEvent;

    public delegate void OnStunDelegate();
    public event OnStunDelegate OnStunEvent;

    public virtual void HealthChanged(int dmg)
    {
        if (this.health <= 0)
        {
            OnDeathEvent.Invoke();
            return;
        }

        if (dmg < 0)
        {
            if (this.health - dmg <= this.maxHealth)
            {
                health -= dmg;
            }
            else
            {
                health = maxHealth;
                dmg = maxHealth - health;
            }
        }
        else
        {
            health -= dmg;
        }

        HealthChangedEvent?.Invoke(dmg);
    }

    public bool IsDestroyed()
    {
        return isDestroyed;
    }

    public void GetStun()
    {
        OnStunEvent.Invoke();
    }

    public void GetFire(int dmg, int countMoves)
    {
        damageByFire = dmg / 3;
        countMovesToFire = countMoves;
        Console.WriteLine($"{name} is fired");
    }

    public void GetFreeze(int dmg, int countMoves)
    {
        damageByFreeze = dmg / 5;
        countMovesToFreeze = countMoves;
        Console.WriteLine($"{name} is freezed");
    }

    public string GetName()
    {
        return name;
    }

    public virtual void UpgradeArmor() { }

    public virtual void UpgradeWeapon() { }

    public virtual void UpgradeBow() { }

    private void DamageInfo(int dmg)
    {
        if (dmg > 0)
        {
            Console.WriteLine($"{name} get {dmg} points of damage. Health - {health}");
        }
    }

    private void HealInfo(int value)
    {
        if (value < 0)
        {
            Console.WriteLine($"{name} get {value} points of heal. Health - {health}");
        }
    }

    private void FireDamageInfo(int _)
    {
        if (countMovesToFire > 0)
        {
            health -= damageByFire;
            --countMovesToFire;
            Console.WriteLine($"{name} get {damageByFire} points of damage by fire. Health - {health}");
        }
    }

    private void FreezeDamageInfo(int _)
    {
        if (countMovesToFreeze > 0)
        {
            health -= damageByFreeze;
            --countMovesToFreeze;
            Console.WriteLine($"{name} get {damageByFreeze} points of damage by freeze. Health - {health}");
        }
    }
}