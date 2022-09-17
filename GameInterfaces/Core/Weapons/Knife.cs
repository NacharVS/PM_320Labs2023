using Core.Interfaces;

namespace Core.Weapons;

public class Knife : IMeleeWeapon, IThrowable, IRepairable
{
    public int Damage { get; set; }

    public int Durability { get; set; }
    
    public void Hit()
    {
        Console.WriteLine("Hit by knife");
    }

    public void Throw()
    {
        Console.WriteLine("Knife was thrown");
    }
    
    public void Repair()
    {
        Console.WriteLine("Knife was repaired");
    }
    
    public void DealDamage()
    {
        Console.WriteLine("Deal damage by knife");
    }
}