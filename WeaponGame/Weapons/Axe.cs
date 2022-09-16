using WeaponsInterfaces;

namespace Weapons;

public class Axe : IMeleeWeapon
{
    public int MeleeDamage { get; set; }
    public int  Durability { get; set; }

    public Axe()
    {
        Durability = 5;
        MeleeDamage = 5;
    }

    public void Hit()
    {
        if (Durability > 0)
        {
            Durability -= 1;
            Console.WriteLine($"{GetType().Name} hit. Damage: {MeleeDamage}. Durability {Durability}");
        }
        else
        {
            Console.WriteLine("Durabiliyu - 0!");
        }
    }

    public void Repair()
    {
        Console.WriteLine($"{GetType().Name} Repaired. {Durability} => {Durability += 3}");
    }

    public void Upgrade()
    {
        MeleeDamage += 8;
        Console.WriteLine($"{GetType().Name} damage updated! New damage {MeleeDamage}");
    }
}