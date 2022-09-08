namespace RTS.Core.Logger;

public interface ILogger
{
    public void Log(LogMessageType type, string msg);
}