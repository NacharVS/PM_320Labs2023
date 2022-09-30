using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CharacterEditor.MongoDB;

public class AbilityDb
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; internal set; } = null!;

    [BsonIgnoreIfNull] public string? Name { get; set; }
    [BsonIgnoreIfDefault] public int HealthChange { get; set; }
    [BsonIgnoreIfDefault] public int ManaChange { get; set; }
    [BsonIgnoreIfDefault] public int PhysicalResistanceChange { get; set; }
    [BsonIgnoreIfDefault] public int AttackChange { get; set; }
    [BsonIgnoreIfDefault] public int MagicalAttackChange { get; set; }
}