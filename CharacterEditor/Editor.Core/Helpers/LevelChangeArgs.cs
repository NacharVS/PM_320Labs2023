namespace Editor.Core.Helpers;

public class LevelChangeArgs : EventArgs
{
    public int Level { get; set; }

    public LevelChangeArgs(int level)
    {
        Level = level;
    }
}