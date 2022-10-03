using CharacterEditor.Core.Misc;

namespace CharacterEditor.MongoDB;

public class ItemDb : CanChangeStatsDb
{
    public string? Name { get; internal set; }
    public string ClassName { get; internal set; }
    public ItemType Type { get; internal set; }
    public int MinimumLevel { get; internal set; }
}