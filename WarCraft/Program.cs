using Units.ActiveUnits;
using Units.BaseUnits;

Footman playerOne = new(80, 100, 10, 15, "Footer");
Peasant playerTwo = new(100, "Bulat");
Mage playerThree = new(80, 100, 10, 100, 100, 4, "Mage");
Blacksmith blacksmith = new(1000, "Blacksmith");
List<Unit> units = new List<Unit>() { playerOne, playerTwo, playerThree, blacksmith};

blacksmith.UpgradeWeapon(units);

try
{
    while (true)
    {
        playerOne.Attack(playerTwo);
        playerThree.Attack(playerOne);
    }
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine(playerOne.GetStateOfLife() 
        ? $"First player ({playerOne.Name}) is victorious!" 
        : $"Second player({playerTwo.Name}) is victorious!");
}
