namespace WeaponsInterfaces;

public interface IThrowable
{
    int ThrowDamage { get; set; }

    void Throw();
}