namespace WeaponsInterfaces;

public interface IRepairable
{
    public int Durability { get; set; }
    void Repair();
}