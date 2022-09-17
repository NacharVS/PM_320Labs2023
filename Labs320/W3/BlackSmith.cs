using System;

public class BlackSmith : Unit
{
    public BlackSmith(int bsmthHealth, string bsmthName)
    {
        health = bsmthHealth;
        name = bsmthName;
    }

    public void UpgradeArmor(Military unit)
    {
        Console.WriteLine($"{unit.name} armor was upgraded by {name}. {unit.name} armor: {unit.armor}");
        unit.armor += 2;
    }

    public void UpgradeWeapon(Military unit)
    {
        Console.WriteLine($"{unit.name} damage was upgraded by {name}. {unit.name} damage: {unit.damage}");
        unit.damage += 4;
    }

    public void UpgradeBow(Archer unit)
    {
        Console.WriteLine($"{unit.name} bow was upgraded by {name}. {unit.name} damage: {unit.damage}, arrow count: {unit.arrowCount}");
        unit.damage += 4;
        unit.arrowCount += 5;
    }
}
