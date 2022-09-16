using Weaponry.Interfaces;

namespace Weaponry.Weapons;

public class Ak47Rifle : IAutoShootFiregun
{
    public int Damage { get; set; }
    public int CurrentMagazineSize { get; set; }
    public int MaximumMagazineSize { get; set; }
    public int State { get; set; }

    public Ak47Rifle(int magazineSize)
    {
        MaximumMagazineSize = magazineSize;
        CurrentMagazineSize = magazineSize;
    }

    public void Repair()
    {
        State += 1;
        Console.WriteLine("Ак-47 отремонтирован");
    }

    public void Upgrade()
    {
        Damage += 5;
        Console.WriteLine("Ак-47 улучшен");
    }

    public void SingleShoot()
    {
        Console.WriteLine(
            $"Из АК-47 выпущен выстрел на {Damage} урона");
        CurrentMagazineSize--;
    }

    public void Reload()
    {
        Console.WriteLine($"Произведена перезарядка АК-47. Количество патронов: {CurrentMagazineSize} -> {MaximumMagazineSize}");
        CurrentMagazineSize = MaximumMagazineSize;
    }

    public void Autoshoot()
    {
        Console.WriteLine(
            $"Из АК-47 выпущена очередь из {CurrentMagazineSize} патронов на {Damage * MaximumMagazineSize} урона");
    }
}