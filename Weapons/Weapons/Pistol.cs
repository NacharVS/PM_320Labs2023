class Pistol : IWeapon
{
    private int _damage;
    private int _durability;
    private int _maxDurability;

    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    public int Durability
    {
        get { return _durability; }
        set { _durability = value; }
    }

    public Pistol(int durability)
    {
        _durability = durability;
        _maxDurability = durability;
        _damage = 7;
    }

    public void SingleShoot()
    {
        if (Durability < 2)
        {
            Console.WriteLine("Pistol is broken");
        }
        else
        {
            Console.WriteLine($"Pistol shooting with {Damage}");
            Durability -= 2;
        }
    }

    public void Reload()
    {
        Console.WriteLine("Pistol is reloaded");
    }

    public void Repair()
    {
        Durability += 4;
        Console.WriteLine("Katana has repaired by 4");

        if (Durability > _maxDurability)
        {
            Durability = _maxDurability;
        }
    }

    public void UpgradeDamage()
    {
        Damage += 6;
        Console.WriteLine($"new damage {Damage}");
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Pistol durability {Durability}");
    }
}
