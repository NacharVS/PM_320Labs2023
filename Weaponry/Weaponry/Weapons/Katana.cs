using Weaponry.Interfaces;

namespace Weaponry.Weapons;

public class Katana : IMeleeWeapon
{
    public int State { get; set; }
    public int MeleeDamage { get; set; }

    public void Repair()
    {
        State += 1;
        Console.WriteLine("Катана отремонтирована");
    }

    public void Upgrade()
    {
        MeleeDamage += 5;
        Console.WriteLine("Катана улучшена");
    }

    public void MeleeAttack()
    {
        Console.WriteLine($"Нанесена атака катаной на {MeleeDamage} урона");
    }
}