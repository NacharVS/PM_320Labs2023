using CharacterEditor.Core.Misc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CharacterEditor.MongoDB;

public class ItemDb : CanChangeStatsDb
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; internal set; } = null!;

    public string? Name { get; internal set; }
    public string ClassName { get; internal set; }
    public ItemType Type { get; internal set; }
    public int MinimumLevel { get; internal set; }
}