using CharacterCreator.Core;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CharacterCreator.Data.Models;

public class EquipmentDbModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonIgnoreIfDefault] public string? Name { get; set; }
    [BsonIgnoreIfDefault] public int RequiredLevel { get; set; }

    [BsonIgnoreIfDefault] public double RequiredStrength { get; set; }
    [BsonIgnoreIfDefault] public double RequiredDexterity { get; set; }
    [BsonIgnoreIfDefault] public double RequiredConstitution { get; set; }
    [BsonIgnoreIfDefault] public double RequiredIntelligence { get; set; }


    [BsonIgnoreIfDefault] public double Strength { get; set; }
    [BsonIgnoreIfDefault] public double Constitution { get; set; }
    [BsonIgnoreIfDefault] public double Dexterity { get; set; }
    [BsonIgnoreIfDefault] public double Intelligence { get; set; }
    [BsonIgnoreIfDefault] public double HealthPoint { get; set; }
    [BsonIgnoreIfDefault] public double ManaPoint { get; set; }
    [BsonIgnoreIfDefault] public double PhysAttack { get; set; }
    [BsonIgnoreIfDefault] public double PhysDefense { get; set; }
    [BsonIgnoreIfDefault] public double MagicalAttack { get; set; }

    [BsonIgnoreIfDefault] public string EquipmentType { get; set; }
    [BsonIgnoreIfDefault] public bool IsEquipped { get; set; }

    public EquipmentDbModel(string equipmentType, string? name, int requiredLevel, double requiredStrength,
        double requiredDexterity, double requiredConstitution, double requiredIntelligence, double strength,
        double constitution, double dexterity, double intelligence, double healthPoint, 
        double manaPoint, double physAttack, double physDefense, double magicalAttack, bool isEquipped)
    {
        EquipmentType = equipmentType;
        Name = name;
        RequiredLevel = requiredLevel;
        RequiredStrength = requiredStrength;
        RequiredDexterity = requiredDexterity;
        RequiredConstitution = requiredConstitution;
        RequiredIntelligence = requiredIntelligence;
        Strength = strength;
        Constitution = constitution;
        Dexterity = dexterity;
        Intelligence = intelligence;
        HealthPoint = healthPoint;
        ManaPoint = manaPoint;
        PhysAttack = physAttack;
        PhysDefense = physDefense;
        MagicalAttack = magicalAttack;
        IsEquipped = isEquipped;
    }
}