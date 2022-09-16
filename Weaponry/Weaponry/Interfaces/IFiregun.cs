namespace Weaponry.Interfaces;

public interface IFiregun : IReloadable
{
    public int Damage { get; set; }

    public void SingleShoot();
}