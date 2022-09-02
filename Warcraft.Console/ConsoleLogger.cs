using Warcraft.Core;

namespace Warcraft.Console;

public class ConsoleLogger : IEventLogger
{
    public void LogInfo(Unit unit, string message)
    {
        System.Console.WriteLine($"{unit.Name}: {message}");
    }
}