using WeaponsInterfaces;

namespace Weapons;

public class Shuriken : IThrowable
{
    private int _throwDamage;

    public int ThrowDamage
    {
        get => _throwDamage;
        set => _throwDamage = value;
    }

    public Shuriken()
    {
        _throwDamage = 10;
    }

    public void Throw()
    {
        Console.WriteLine($"{GetType().Name} get throwed.");
    }
}