using WeaponsInterfaces;

namespace Weapons;

public class Knife : IMeleeWeapon, IThrowable
{
    public int MeleeDamage { get; set; }
    public int ThrowDamage { get; set; }
    public int Durability { get; set; }

    public Knife()
    {
        MeleeDamage = 5;
        ThrowDamage = 5;
        Durability = 10;
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
        MeleeDamage += 5;
        ThrowDamage += 5;
        Console.WriteLine($"{GetType().Name} damage updated! New melee damage {MeleeDamage}," +
                          $"new throw damage {ThrowDamage}");
    }

    public void Throw()
    {
        Console.WriteLine($"{GetType().Name} get throwed, cause {ThrowDamage} damage.");
    }
}