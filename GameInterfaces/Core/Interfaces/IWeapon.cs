namespace Core.Interfaces;

public interface IWeapon
{
    public int Damage { get; set; }

    public void DealDamage();
}