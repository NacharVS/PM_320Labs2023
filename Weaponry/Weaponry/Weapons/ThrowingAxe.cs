using Weaponry.Interfaces;

namespace Weaponry.Weapons;

public class ThrowingAxe : IMeleeWeapon, IThrowable
{
    public int MeleeDamage { get; set; }
    public int ThrowDamage { get; set; }
    public int State { get; set; }

    public void Repair()
    {
        State += 1;
        Console.WriteLine("Метательный топор отремонтирован");
    }

    public void Upgrade()
    {
        MeleeDamage += 5;
        Console.WriteLine("Метательный топор улучшен");
    }

    public void MeleeAttack()
    {
        Console.WriteLine(
            $"Нанесена атака метательным топором на {MeleeDamage} урона");
    }

    public void Throw()
    {
        Console.WriteLine($"Метательный топор выкинут на {ThrowDamage} урона");
    }
}