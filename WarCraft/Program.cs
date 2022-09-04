using Units;



Dragon playerOne = new(80, 0, 10, 15, 100, 4);
Footman playerTwo = new(100, 40, 4, 8);

try
{
    while (true)
    {
        playerOne.Attack(playerTwo);
        playerOne.FireBreath(playerTwo);
        playerTwo.Attack(playerOne);
    }
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine(playerOne.GetStateOfLife() 
        ? $"First player ({playerOne.GetType().Name}) is victorious!" 
        : $"Second player({playerTwo.GetType().Name}) is victorious!");
}
