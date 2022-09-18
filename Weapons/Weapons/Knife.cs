class Knife : IMleeWeapon, IThrowable
{
    private int _mleeDamage = 4;
    public int ThrowDamage => 4;
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

    public Knife(int durability)
    {
        _durability = durability;
        _maxDurability = durability;
    }

    public void Hit()
    {
        if (Durability < 2)
        {
            Console.WriteLine("Knife is broken");
        }
        else
        {
            Console.WriteLine($"Knife inflicted of {MleeDamage} mlee damage");
            Durability -= 2;
        }
    }

    public void Throw()
    {
        Console.WriteLine($"Knife inflicted of {ThrowDamage} throwable damage");
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Knife durability {Durability}");
    }

    public void Repair()
    {
        Durability += 4;
        Console.WriteLine("Knife has repaired by 4");

        if (Durability > _maxDurability)
        {
            Durability = _maxDurability;
        }
    }

    public void UpgradeDamage()
    {
        MleeDamage += 4;
        Console.WriteLine($"new mlee damage {MleeDamage}");
    }
}
