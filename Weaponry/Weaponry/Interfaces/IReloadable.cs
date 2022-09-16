namespace Weaponry.Interfaces;

public interface IReloadable
{
    public int CurrentMagazineSize { get; set; }
    public int MaximumMagazineSize { get; set; }
    public void Reload();
}