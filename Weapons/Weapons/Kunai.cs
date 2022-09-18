class Kunai : IMleeWeapon, IThrowable
{
    private int _mleeDamage = 5;
    public int ThrowDamage => 5;
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

    public Kunai(int durability)
    {
        _durability = durability;
        _maxDurability = durability;
    }

    public void Hit()
    {
        if (Durability < 2)
        {
            Console.WriteLine("Kunai is broken");
        }
        else
        {
            Console.WriteLine($"Kunai inflicted of {MleeDamage} mlee damage");
            Durability -= 2;
        }
    }

    public void Throw()
    {
        Console.WriteLine($"Kunai inflicted of {ThrowDamage} throwable damage");
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Kunai durability {Durability}");
    }

    public void Repair()
    {
        Durability += 4;
        Console.WriteLine("Kunai has repaired by 4");

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