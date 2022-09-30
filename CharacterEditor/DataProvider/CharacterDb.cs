using Editor.Core;
using MongoDB.Bson.Serialization.Attributes;

namespace DataProvider
{
    public class CharacterDb
    {
        [BsonId]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int AvailableSkillPoints { get; set; }
        public int Experience { get; set; }

        public CharacterDb(int id, string? name, int strength, int dexterity, int constitution, 
            int intelligence, int availableSkillPoints, int experience)
        {
            Id = id;
            Name = name;
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            AvailableSkillPoints = availableSkillPoints;
            Experience = experience;
        }

        public CharacterDb(Character character)
        {
            Name = character.GetType().ToString();
            Strength = character.Strength;
            Dexterity = character.Dexterity;
            Constitution = character.Constitution;
            Intelligence = character.Intelligence;
            AvailableSkillPoints = character.AvailableSkillPoints;
            Experience = character.Experience;
        }

        public CharacterDb(int id, Character character)
        {
            Id = id;
            Name = character.GetType().ToString();
            Strength = character.Strength;
            Dexterity = character.Dexterity;
            Constitution = character.Constitution;
            Intelligence = character.Intelligence;
            AvailableSkillPoints = character.AvailableSkillPoints;
            Experience = character.Experience;
        }
    }
}
