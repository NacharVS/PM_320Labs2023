using System.Runtime.CompilerServices;
using CharacterCreator.Core;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CharacterCreator.Data.Models;

public class CharacterDbModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonIgnoreIfDefault] public string? ClassName { get; set; }
    [BsonIgnoreIfDefault] public string Name { get; set; }
    [BsonIgnoreIfDefault] public double Strength { get; set; }
    [BsonIgnoreIfDefault] public double Dexterity { get; set; }
    [BsonIgnoreIfDefault] public double Intelligence { get; set; }
    [BsonIgnoreIfDefault] public double Constitution { get; set; }
    [BsonIgnoreIfDefault] public int SkillPoints { get; set; }
    [BsonIgnoreIfDefault] public IEnumerable<BaseItem> Inventory { get; set; }

    [BsonIgnoreIfDefault] public int Experience { get; set; }
    [BsonIgnoreIfDefault] public IEnumerable<Ability> Abilities { get; set; }

    public CharacterDbModel(Character c)
    {
        Name = c.Name;
        ClassName = c.GetType().Name;
        Strength = c.Strength;
        Dexterity = c.Dexterity;
        Intelligence = c.Intelligence;
        Constitution = c.Constitution;
        SkillPoints = c.SkillPoints;
        Inventory = c.Inventory;
        Experience = c.Level.TotalExperience;
        Abilities = c.Abilities;
    }

    public CharacterDbModel(string id, Character c)
    {
        Id = id;
        Name = c.Name;
        ClassName = c.GetType().Name;
        Strength = c.Strength;
        Dexterity = c.Dexterity;
        Intelligence = c.Intelligence;
        Constitution = c.Constitution;
        SkillPoints = c.SkillPoints;
        Inventory = c.Inventory;
        Experience = c.Level.TotalExperience;
        Abilities = c.Abilities;
    }
}