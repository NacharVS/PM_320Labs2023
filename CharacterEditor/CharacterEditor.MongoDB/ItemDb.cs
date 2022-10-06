using CharacterEditor.Core.Misc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CharacterEditor.MongoDB;

public class ItemDb : CanChangeStatsDb
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonIgnoreIfNull]
    public string Id { get; internal set; } = null!;

    [BsonIgnoreIfDefault] public int StrengthChange { get; init; }
    [BsonIgnoreIfDefault] public int DexterityChange { get; init; }
    [BsonIgnoreIfDefault] public int ConstitutionChange { get; init; }
    [BsonIgnoreIfDefault] public int IntelligenceChange { get; init; }

    [BsonIgnoreIfDefault] public string? Name { get; internal set; }
    [BsonIgnoreIfDefault] public string? ClassName { get; internal set; }
    [BsonIgnoreIfDefault] public ItemType Type { get; internal set; }
    [BsonIgnoreIfDefault] public int MinimumLevel { get; internal set; }
}