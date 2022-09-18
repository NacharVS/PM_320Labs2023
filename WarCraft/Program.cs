using Units.ActiveUnits;
using Units.BaseUnits;

Footman f1 = new(80, 100, 10, 15, "Alexander");
Peasant p1 = new(100, "Bulat");
Mage m1 = new(80, 100, 10, 100, 100, 4, "Mage");
Mage m2 = new(80, 100, 10, 100, 100, 4, "UltraMaga");
Footman f2 = new(80, 100, 10, 15, "Magomed");

Blacksmith blacksmith = new(1000, "Blacksmith");
List<Unit> units = new List<Unit>() { f1, p1, m1, m2, f2};
blacksmith.UpgradeWeapon(units);

Random rand = new Random();

Unit playerOne;
Unit playerTwo;

while (units.Count > 1)
{
    playerOne = units[rand.Next(units.Count)];
    playerTwo = units[rand.Next(units.Count)];

    if(playerOne == playerTwo)
    {
        continue;
    }

    playerOne.Attack(playerTwo);
    playerTwo.Attack(playerOne);

    if(!playerOne.GetStateOfLife())
    {
        units.Remove(playerOne);
    }
    else if(!playerTwo.GetStateOfLife())
    {
        units.Remove(playerTwo);
    }
}
Console.WriteLine($"{units[0].Name} won this battle!!!");