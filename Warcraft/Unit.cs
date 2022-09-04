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
        this.isStun = false;
        this.countMovesToFire = 0;
        this.countMovesToFreeze = 0;
        Units.units.Add(this);
    }
    
    protected int health;
    protected int cost;
    protected string name;
    protected bool isDestroyed;
    protected int lvl;
    protected int maxHealth;
    protected bool isStun;
    protected int countMovesToFire;
    protected int damageByFire;
    protected int countMovesToFreeze;
    protected int damageByFreeze;

    public virtual void GetDamage(int dmg)
    {
        health -= dmg;
        Console.WriteLine($"{name} get {dmg} damage");
        
        if (health <= 0)
        {
            isDestroyed = true;
            Console.WriteLine($"{name} is dead");
            return;
        }

        if (countMovesToFire > 0)
        {
            health -= damageByFire;
            --countMovesToFire;
            Console.WriteLine($"{name} get {damageByFire} damage by fire");
        }

        if (countMovesToFreeze > 0)
        {
            health -= damageByFreeze;
            --countMovesToFreeze;
            Console.WriteLine($"{name} get {damageByFreeze} damage by freeze");
        }
    }

    public bool IsDestroyed()
    {
        return isDestroyed;
    }

    public void GetStun()
    {
        Console.WriteLine($"{name} is stunned");
        isStun = true;
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

    public void GetHeal(int heal)
    {
        health += heal;
        Console.WriteLine($"{name} is healed");
    }

    public string GetName()
    {
        return name;
    }

    public virtual void UpgradeArmor() { }

    public virtual void UpgradeWeapon() { }

    public virtual void UpgradeBow() { }
}