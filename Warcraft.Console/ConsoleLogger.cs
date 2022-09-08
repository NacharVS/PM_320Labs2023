using Warcraft.Core;
using Warcraft.Core.BaseClasses;

namespace Warcraft.Console;

public class ConsoleLogger : IEventLogger
{
    public void LogInfo(Unit unit, string message)
    {
        System.Console.WriteLine($"{unit.Name}: {message}");
    }
}