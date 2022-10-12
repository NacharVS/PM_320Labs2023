using CharacterEditor.Core.Matching;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CharacterEditor.MongoDB;

public class MatchDb
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonIgnoreIfNull]
    public string Id { get; init; }

    [BsonIgnoreIfDefault] public DateTime DateStarted { get; init; }
    public Team TeamA { get; init; }
    public Team TeamB { get; init; }
}