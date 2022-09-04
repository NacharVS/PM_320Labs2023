using Units;



Dragon playerOne = new(80, 100, 10, 15, 100, 4, "SuperDrago");
Archer playerTwo = new(80, 0, 10, 15, 100, 4, 15, "Master of bows");

try
{
    while (true)
    {
        playerOne.FireBreath(playerTwo);
        playerTwo.Attack(playerOne);
    }
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine(playerOne.GetStateOfLife() 
        ? $"First player ({playerOne.Name}) is victorious!" 
        : $"Second player({playerTwo.Name}) is victorious!");
}
