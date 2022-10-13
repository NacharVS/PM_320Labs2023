using CharacterCreator.Core;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CharacterCreator.Data.Models;

public class AbilityDbModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonIgnoreIfNull] public string? Name { get; set; }
    [BsonIgnoreIfDefault] public int RequiredLevel { get; set; }
    [BsonIgnoreIfDefault] public int HealthChangeValue { get; set; }
    [BsonIgnoreIfDefault] public int ManaChangeValue { get; set; }
    [BsonIgnoreIfDefault] public int ManaAttackChangeValue { get; set; }

    [BsonIgnoreIfDefault] public int PhysAttackChangeValue { get; set; }
    [BsonIgnoreIfDefault] public int PhysDefenseChangeValue { get; set; }

    public AbilityDbModel(Ability a)
    {
        Name = a.Name;
        RequiredLevel = a.RequiredLevel;
        HealthChangeValue = a.HealthChangeValue;
        ManaChangeValue = a.ManaChangeValue;
        ManaAttackChangeValue = a.ManaAttackChangeValue;
        PhysAttackChangeValue = a.PhysAttackChangeValue;
        PhysDefenseChangeValue = a.PhysDefenseChangeValue;
    }
}