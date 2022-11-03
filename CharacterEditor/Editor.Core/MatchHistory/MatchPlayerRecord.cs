using Editor.Core.Characters.interfaces;

namespace Editor.Core.MatchHistory;

public class MatchPlayerRecord : IHaveName
{
    public string? Name { get; set; }
    public string CharacterName { get; set; }
    public string TeamName { get; set; }

    public MatchPlayerRecord(string id, string? name, string characterName, string teamName)
    {
        Name = name;
        CharacterName = characterName;
        TeamName = teamName;
    }
}