using CharacterEditor.Core.Characteristics;

namespace CharacterEditor.Core;

public class CharacterInfo
{
    public string Id { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string ClassName { get; init; } = string.Empty;
    public int Level { get; init; }

    public CharacterInfo(int xp = 0)
    {
        Level = new LevelInfo(xp).CurrentLevel;
    }
}