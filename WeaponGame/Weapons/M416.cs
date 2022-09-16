using WeaponsInterfaces;

namespace Weapons;

public class M416 : IWeapon, IAutoShoot
{
    public int Damage { get; set; }
    public int MagazineCharge { get; set; }
    public int MaxMagazineCharge { get; set; }
    public int Durability { get; set; }

    public M416(int magazineCharge)
    {
        MaxMagazineCharge = magazineCharge;
        MagazineCharge = MaxMagazineCharge;
        Durability = 100;
        Damage = 10;
    }
    
    public void Shot()
    {
        if (MagazineCharge > 0 && Durability > 0)
        {
            MagazineCharge -= 1;
            Durability -= 1;
            Console.WriteLine($"{GetType().Name} caused {Damage} damage." +
                              $" {MagazineCharge} bullets left. Durability {Durability}");
        }
        else
        {
            Console.WriteLine("Not have a bullets or durability - 0!");
        }
    }

    public void Upgrade()
    {
        Damage += 8;
        Console.WriteLine($"{GetType().Name} damage updated! New damage {Damage}");
    }

    public void Repair()
    {
        Console.WriteLine($"{GetType().Name} Repaired. {Durability} => {Durability += 10}");
    }

    public void Reload()
    {
        Console.WriteLine($"{GetType().Name} Reloaded. {MagazineCharge} => {MaxMagazineCharge}");
        MagazineCharge = MaxMagazineCharge;
    }

    public void AutoShoot()
    {
        if (MagazineCharge > 0 && Durability > 0)
        {
            Durability -= MagazineCharge;
            Console.WriteLine($"{GetType().Name} fired in bursts {MagazineCharge} bullets " +
                              $"caused {Damage * MagazineCharge} damage. Durability {Durability}");
            MagazineCharge = 0;
        }
        else
        {
            Console.WriteLine("Not have a bullets or durability - 0!");
        }
    }
}