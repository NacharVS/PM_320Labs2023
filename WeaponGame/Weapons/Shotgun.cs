using WeaponsInterfaces;

namespace Weapons;

public class Shotgun : IWeapon, ITripleShot
{
    public int Durability { get; set; }
    public int Damage { get; set;}
    public int MagazineCharge { get; set; }
    public int MaxMagazineCharge {get; set; }
    public Shotgun(int magazineCharge)
    {
        Damage = 15;
        Durability = 10;
        MaxMagazineCharge = magazineCharge;
        MagazineCharge = MaxMagazineCharge;
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
        Damage += 10;
        Console.WriteLine($"{GetType().Name} damage updated! New damage {Damage}");
    }

    public void Repair()
    {
        Console.WriteLine($"{GetType().Name} Repaired. {Durability} => {Durability += 5}");
    }

    public void Reload()
    {
        Console.WriteLine($"{GetType().Name} Reloaded. {MagazineCharge} => {MaxMagazineCharge}");
        MagazineCharge = MaxMagazineCharge;
    }

    public void TripleShot()
    {
        if (MagazineCharge > 0 && Durability > 0)
        {
            MagazineCharge -= 1;
            Durability -= 1;
            Console.WriteLine($"{GetType().Name} caused {Damage * 3} damage." +
                              $" {MagazineCharge} bullets left. Durability {Durability}");
        }
        else
        {
            Console.WriteLine("Not have a bullets or durability - 0!");
        }
    }
}