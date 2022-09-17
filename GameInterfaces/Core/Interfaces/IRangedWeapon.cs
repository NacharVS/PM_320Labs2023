namespace Core.Interfaces;

public interface IRangedWeapon : IWeapon
{
    public int Distance { get; set; }
}