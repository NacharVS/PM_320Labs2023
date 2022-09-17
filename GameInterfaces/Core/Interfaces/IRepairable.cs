namespace Core.Interfaces;

public interface IRepairable
{
    public int Durability { get; set; }
    
    public void Repair();
}