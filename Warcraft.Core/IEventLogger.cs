using Warcraft.Core.BaseClasses;

namespace Warcraft.Core;

public interface IEventLogger
{
    public void LogInfo(Unit unit, string message);
}