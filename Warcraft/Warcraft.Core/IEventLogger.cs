using Warcraft.Core.BaseClasses;

namespace Warcraft.Core;

public interface IEventLogger
{
    public void LogInfo(Unit unit, string message);
}

public abstract class EventLogger
{
    public virtual void LogInfo(Unit unit, string message)
    {
        Console.WriteLine("'123123123");
    }
}