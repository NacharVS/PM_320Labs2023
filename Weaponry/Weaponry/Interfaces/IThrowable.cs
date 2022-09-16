namespace Weaponry.Interfaces;

public interface IThrowable
{
    public int ThrowDamage { get; set; }

    public void Throw();
}