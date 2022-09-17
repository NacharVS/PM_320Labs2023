using Core.Interfaces;

namespace Core.Weapons;

public class Rifle : IHaveSingleMode, IUpgradable
{
    public int Damage { get; set; }
    public int Distance { get; set; }
    
    public void Reload()
    {
        Console.WriteLine("Rifle was reloaded");
    }

    public void SingleShoot()
    {
        Console.WriteLine("Single shot from rifle");
    }

    public void Upgrade()
    {
        Console.WriteLine("Rifle was upgraded");
    }

    public void DealDamage()
    {
        Console.WriteLine("Damage deal by Rifle");
    }
}