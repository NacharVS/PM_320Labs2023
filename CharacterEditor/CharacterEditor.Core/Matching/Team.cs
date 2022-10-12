namespace CharacterEditor.Core.Matching;

public class Team
{
    public const int MaximumParticipants = 6;

    public string Name { get; init; } = string.Empty;
    private readonly List<CharacterInfo> _characters;

    public CharacterInfo[] Characters
    {
        get => _characters.ToArray();
        set
        {
            foreach (var character in value)
                AddCharacter(character);
        }
    }

    public void AddCharacter(CharacterInfo characterInfo)
    {
        if (_characters.Count < MaximumParticipants)
        {
            _characters.Add(characterInfo);
        }
    }

    public Team()
    {
        _characters = new();
    }
}