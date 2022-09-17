using System.Text;
using Warcraft.Core;
using Warcraft.Core.BaseClasses;

namespace Warcraft.Console;

public class FileLogger : IEventLogger
{
    private const string Filename = "output.txt";
    private const string DefaultSource = "System";

    public void LogInfo(Unit? unit, string message)
    {
        using (var file = new StreamWriter(File.Open(Filename, FileMode.Append,
                   FileAccess.Write)))
        {
            file.WriteLine(
                $"{(unit?.Name is null ? DefaultSource : unit.Name)}: {message}");
        }
    }
}