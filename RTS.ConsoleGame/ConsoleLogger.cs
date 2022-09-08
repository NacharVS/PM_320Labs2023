using RTS.Core.Logger;

namespace RTS.ConsoleGame;

public class ConsoleLogger : ILogger
{
    public void Log(LogMessageType type, string msg)
    {
        Console.WriteLine($"[{type}]: {msg}");
    }
}