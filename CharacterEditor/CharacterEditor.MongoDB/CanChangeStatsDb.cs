using CharacterEditor.Core.Misc;
using MongoDB.Bson.Serialization.Attributes;

namespace CharacterEditor.MongoDB;

public class CanChangeStatsDb : ICanChangeStats
{
    [BsonIgnoreIfDefault] public int HealthChange { get; init; }
    [BsonIgnoreIfDefault] public int ManaChange { get; init; }
    [BsonIgnoreIfDefault] public int PhysicalResistanceChange { get; init; }
    [BsonIgnoreIfDefault] public int AttackChange { get; init; }
    [BsonIgnoreIfDefault] public int MagicalAttackChange { get; init; }
}