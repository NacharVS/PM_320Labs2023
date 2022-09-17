using Core.Interfaces;

namespace Core.Characters;

public class Soldier
{
    public IWeapon[] Weapons { get; set; }
    public IWeapon ActiveWeapon { get; set; }

    public Soldier(IWeapon[] weapons)
    {
        Weapons = weapons;
        ActiveWeapon = weapons[0];
    }

    public void Attack()
    {
        ActiveWeapon.DealDamage();
    }

    public void ChangeWeapon(int weaponPos)
    {
        ActiveWeapon = Weapons[weaponPos];
    }
}