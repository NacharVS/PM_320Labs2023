class Katana : IMleeWeapon
{
    private int _mleeDamage;
    private int _durability;
    private int _maxDurability;

    public int MleeDamage
    {
        get { return _mleeDamage; }
        set { _mleeDamage = value; }
    }

    public int Durability 
    { 
        get { return _durability; } 
        set { _durability = value; }
    }

    public Katana(int durability)
    {
        _durability = durability;
        _maxDurability = durability;
        _mleeDamage = 5;
    }

    public void Hit()
    {
        if (Durability < 2)
        {
            Console.WriteLine("Katana is broken");
        }
        else
        {
            Console.WriteLine($"Katana inflicted of {MleeDamage} mlee damage");
            Durability -= 2;
        }
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Katana durability {Durability}");
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
        MleeDamage += 5;
        Console.WriteLine($"new mlee damage {MleeDamage}");
    }
}