class Machinegun : IWeapon, ITripleShoot
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

    public Machinegun(int durability)
    {
        _durability = durability;
        _maxDurability = durability;
        _damage = 8;
    }

    public void SingleShoot()
    {
        if (Durability < 2)
        {
            Console.WriteLine("Machinegun is broken");
        }
        else
        {
            Console.WriteLine($"Machinegun shooting with {Damage}");
            Durability -= 2;
        }
    }

    public void TripleShoot()
    {
        if (Durability < 6)
        {
            Console.WriteLine("Machinegun is broken");
        }
        else
        {
            Console.WriteLine($"Machinegun shooting with {Damage * 3}");
            Durability -= 6;
        }
    }

    public void Reload()
    {
        Console.WriteLine("Machinegun is reloaded");
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
        Console.WriteLine($"Machinegun durability {Durability}");
    }
} 