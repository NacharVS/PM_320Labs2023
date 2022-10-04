using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CharacterEditor.MongoDB;

public class AbilityDb : CanChangeStatsDb
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonIgnoreIfNull]
    public string Id { get; internal set; } = null!;

    [BsonIgnoreIfNull] public string? Name { get; set; }
}