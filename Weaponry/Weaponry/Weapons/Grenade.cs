using Weaponry.Interfaces;

namespace Weaponry.Weapons;

public class Grenade : IThrowable
{
    public int ThrowDamage { get; set; }

    public void Throw()
    {
        Console.WriteLine($"Выброшена граната, нанесшая {ThrowDamage} урона");
    }
}