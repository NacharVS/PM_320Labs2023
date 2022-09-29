using MongoDB.Bson.Serialization.Attributes;

namespace CharacterEditor.MongoDB;

public class AbilityDb
{
    [BsonIgnoreIfNull] public string Name { get; set; }
    [BsonIgnoreIfDefault] public int HealthChange { get; set; }
    [BsonIgnoreIfDefault] public int ManaChange { get; set; }
    [BsonIgnoreIfDefault] public int PhysicalResistanceChange { get; set; }
    [BsonIgnoreIfDefault] public int AttackChange { get; set; }
    [BsonIgnoreIfDefault] public int MagicalAttackChange { get; set; }
}