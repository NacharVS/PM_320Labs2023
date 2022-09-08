using System.Text;
using Warcraft.Core;
using Warcraft.Core.BaseClasses;

namespace Warcraft.Console;

public class FileLogger : IEventLogger
{
    private string filename = "output.txt";
    public void LogInfo(Unit unit, string message)
    {
        using (var file = new StreamWriter(File.Open(filename, FileMode.Append, FileAccess.Write)))
        {
            file.WriteLine($"{unit.Name}: {message}");
        }
    }
}