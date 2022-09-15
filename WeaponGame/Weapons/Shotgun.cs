using WeaponsInterfaces;

namespace Weapons;

public class Shotgun : IWeapon
{
    private int _durabiluty;
    private int _damage;
    private int _magazineCharge;
    private int _magazinMaxCharge = 2;

    public Shotgun()
    {
        _damage = 15;
        _durabiluty = 10;
        _magazineCharge = 2;
    }
    public int Damage
    {
        get => _damage;
        set => _damage = value;
    }

    public void Shot()
    {
        if (_magazineCharge > 0)
        {
            _magazineCharge -= 1;
            _durabiluty -= 1;
            Console.WriteLine($"{GetType().Name} caused {_damage} damage." +
                              $" {_magazineCharge} bullets left. Durability {_durabiluty}");
        }
        else
        {
            Console.WriteLine("Not have a bullets!");
        }
    }

    public void Upgrade()
    {
        _damage += 10;
        Console.WriteLine($"Damage updated! New damage {_damage}");
    }

    public void Repair()
    {
        Console.WriteLine($"{GetType().Name} Repaired. {_durabiluty} => {_durabiluty += 5}");
    }

    public void Reload()
    {
        Console.WriteLine($"{GetType().Name} Reloaded. {_magazineCharge} => {_magazinMaxCharge}");
        _magazineCharge = _magazinMaxCharge;
    }
}