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
        this.inStun = false;

    }

    protected int health;
    protected int cost;
    protected string name;
    public bool isDestroyed;
    protected int lvl;
    protected int maxHealth;
    protected bool isStun;
    protected int fireDamage;
    protected int blizzardDamage;
    protected bool inStun;

    public int GetHealth()
    {
        return health;
    }

    public void SetHealth(int health)
    {
        this.health = health;
    }

    public virtual void GetDamage(int dmg)
    {
        health = health - dmg;

        if (health <= 0)
        {
            isDestroyed = true;
            Console.WriteLine($"{name} умер(");
        }
    }

    public void GetStun()
    {
        inStun = true;
        Console.WriteLine($"{name} in stun!");
    }

    public void GetHeal(int heal)
    {
        health += heal;
        Console.WriteLine($"{name} is healing!");
    }

    public string GetName()
    {
        return name;
    }

    public void GetBlizzard(int dmg) 
    {
        health -= blizzardDamage * lvl;
        Console.WriteLine($"{name} is blizzard");
    }

    public void GetFire(int dmg)
    {
        health -= fireDamage * lvl;
        Console.WriteLine($"{name} is fired");
    }

    public bool IsDestroyed()
    {
        return isDestroyed;
    }
}