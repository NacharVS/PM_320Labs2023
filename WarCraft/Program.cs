using Units;



Footman playerOne = new(80, 100, 10, 15, "SuperDrago");
Mage playerTwo = new(80, 100, 10, 100, 100, 4, "SuperMage");

try
{
    while (true)
    {
        playerOne.Attack(playerTwo);
        playerTwo.Heal(playerTwo);
    }
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine(playerOne.GetStateOfLife() 
        ? $"First player ({playerOne.Name}) is victorious!" 
        : $"Second player({playerTwo.Name}) is victorious!");
}
