using Editor.Core.Characters.interfaces;

namespace Editor.Core.MatchHistory;

public class MatchPlayerRecord : IHaveName
{
    public string? Name { get; set; }
    public string CharacterId { get; set; }
    public string TeamName { get; set; }

    public MatchPlayerRecord(string? name, string characterId, string teamName)
    {
        Name = name;
        CharacterId = characterId;
        TeamName = teamName;
    }
}