using Core.Interfaces;

namespace Core.Weapons;

public class Bottle : IThrowable
{
    public int Damage { get; set; }
    
    public void DealDamage()
    {
        Console.WriteLine("Deal damage by bottle");
    }

    public void Throw()
    {
        Console.WriteLine("Bottle was thrown");
    }
}