using Units.ActiveUnits;
using Units.BaseUnits;

Footman playerOne = new(80, 100, 10, 15, "Footer");
Peasant playerTwo = new(100, "Bulat");
List<Unit> units = new List<Unit>() { playerOne, playerTwo };

//Mage playerTwo = new(80, 100, 10, 100, 100, 4, "Mage");

try
{
    while (true)
    {
        playerOne.Attack(playerTwo);
        playerTwo.Mining();
    }
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine(playerOne.GetStateOfLife() 
        ? $"First player ({playerOne.Name}) is victorious!" 
        : $"Second player({playerTwo.Name}) is victorious!");
}
