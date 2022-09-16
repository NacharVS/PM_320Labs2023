using WeaponsInterfaces;

namespace Weapons;

public class Shuriken : IThrowable
{

    public int ThrowDamage { get; set;}

    public Shuriken()
    {
        ThrowDamage = 10;
    }

    public void Throw()
    {
        Console.WriteLine($"{GetType().Name} get throwed, cause {ThrowDamage}");
    }
}