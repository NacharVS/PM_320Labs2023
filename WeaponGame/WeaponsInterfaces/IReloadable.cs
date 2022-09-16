namespace WeaponsInterfaces;

public interface IReloadable
{
    public int MagazineCharge { get; set;}
    public int MaxMagazineCharge { get; set;}
    
    void Reload();
}