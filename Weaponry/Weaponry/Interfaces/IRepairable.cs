namespace Weaponry.Interfaces;

public interface IRepairable
{
    public int State { get; set; }
    public void Repair();
}