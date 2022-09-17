using Core.Interfaces;

namespace Core.Weapons;

public class AssaultRifle : IHaveAutoMode
{
    public int Damage { get; set; }
    public int Distance { get; set; }
    
    public void Reload()
    {
        Console.WriteLine("Assault rifle was reloaded");
    }

    public void AutoModeShoot()
    {
        Console.WriteLine("Auto mode shoot");
    }

    public void DealDamage()
    {
        Console.WriteLine("Deal damage by assault rifle");
    }
    
}