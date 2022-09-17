using Warcraft.Core;
using Warcraft.Core.BaseClasses;

namespace Warcraft.Console;

public class ConsoleLogger : IEventLogger
{
    private const string DefaultSource = "System";

    public void LogInfo(Unit? unit, string message)
    {
        System.Console.WriteLine($"{(unit?.Name is null ? DefaultSource : unit.Name)}: {message}");
    }
}