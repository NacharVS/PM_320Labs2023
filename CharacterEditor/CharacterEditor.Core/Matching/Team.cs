namespace CharacterEditor.Core.Matching;

public class Team
{
    public const int MaximumParticipants = 6;

    public string Name { get; init; } = string.Empty;
    private readonly List<ShortCharacter> _characters;

    public ShortCharacter[] Characters
    {
        get => _characters.ToArray();
        set
        {
            foreach (var character in value)
                AddCharacter(character);
        }
    }

    public void AddCharacter(ShortCharacter shortCharacter)
    {
        if (_characters.Count < MaximumParticipants)
        {
            _characters.Add(shortCharacter);
        }
    }

    public Team()
    {
        _characters = new();
    }
}