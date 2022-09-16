using Weaponry.Interfaces;

namespace Weaponry.Weapons;

public class AwpSniperRifle : IFiregun
{
    public int Damage { get; set; }
    public int CurrentMagazineSize { get; set; }
    public int MaximumMagazineSize { get; set; }
    public int State { get; set; }

    public AwpSniperRifle(int magazineSize)
    {
        MaximumMagazineSize = magazineSize;
        CurrentMagazineSize = magazineSize;
    }
    
    public void Repair()
    {
        State += 1;
        Console.WriteLine("АВП отремонтирован");
    }

    public void Upgrade()
    {
        Damage += 5;
        Console.WriteLine("АВП улучшен");
    }

    public void SingleShoot()
    {
        Console.WriteLine(
            $"Из АВП выпущен выстрел на {Damage} урона");
        CurrentMagazineSize--;
    }

    public void Reload()
    {
        Console.WriteLine($"Произведена перезарядка АВП. Количество патронов: {CurrentMagazineSize} -> {MaximumMagazineSize}");
        CurrentMagazineSize = MaximumMagazineSize;
    }
}