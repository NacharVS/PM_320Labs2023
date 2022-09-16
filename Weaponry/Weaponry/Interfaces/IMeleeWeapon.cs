namespace Weaponry.Interfaces;

public interface IMeleeWeapon
{
    public int MeleeDamage { get; set; }

    public void MeleeAttack();
}