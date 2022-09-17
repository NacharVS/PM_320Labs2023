using Core.Interfaces;

namespace Core.Weapons;

public class Axe : IMeleeWeapon, IRepairable
{
    public int Damage { get; set; }

    public int Durability { get; set; }
    
    public void Hit()
    {
        Console.WriteLine("Hit by axe");
    }

    public void Repair()
    {
        Console.WriteLine("Axe was repaired");
    }
    
    public void DealDamage()
    {
        Console.WriteLine("Deal damage by axe");
    }
}