using CharacterEditor.Core.Characteristics;

namespace CharacterEditor.Core;

public class ShortCharacter
{
    public string Id { get; init; } = String.Empty;
    public string Name { get; init; } = String.Empty;
    public int Level { get; }

    public ShortCharacter(int xp = 0)
    {
        Level = new LevelInfo(xp).CurrentLevel;
    }
}