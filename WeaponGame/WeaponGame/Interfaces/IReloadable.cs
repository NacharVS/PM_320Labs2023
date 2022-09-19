namespace WeaponGame
{
    public interface IReloadable
    {
        int MagazineCapacity { get; } 
        int MaxMagazineCapacity { get; }
        void Reload();
    }
}