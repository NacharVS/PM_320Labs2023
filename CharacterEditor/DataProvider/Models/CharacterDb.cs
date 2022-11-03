using Editor.Core;
using Editor.Core.Abilities;
using Editor.Core.Characters;
using Editor.Core.Inventory;
using MongoDB.Bson.Serialization.Attributes;

namespace DataProvider.Models
{
    public class CharacterDb : BaseModel
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int AvailableSkillPoints { get; set; }
        public int Experience { get; set; }
        public List<Ability?>? Abilities { get; set; }
        public List<Equipment?> Inventory { get; set; }

        public string Class;

        public CharacterDb(string id, string? name, int strength, int dexterity, int constitution, 
            int intelligence, int availableSkillPoints, int experience, IEnumerable<Ability> abilities, string @class)
        {
            Id = id;
            Name = name;
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            AvailableSkillPoints = availableSkillPoints;
            Experience = experience;

            Abilities = new List<Ability?>();
            foreach (var i in abilities)
            {
                Abilities.ToList().Add(new Ability(i.Name, i.RequiredLevel, i.IsApplied));
            }
            Class = @class;
        }

        public CharacterDb(Character character)
        {
            Id = Guid.NewGuid().ToString();
            Name = character.Name ?? character.GetType().Name;
            Strength = character.Strength;
            Dexterity = character.Dexterity;
            Constitution = character.Constitution;
            Intelligence = character.Intelligence;
            AvailableSkillPoints = character.AvailableSkillPoints;
            Experience = character.Experience;
            Inventory = character.Inventory;

            Abilities = new List<Ability?>();
            if (character.Abilities != null)
            {
                foreach (var i in character.Abilities)
                {
                    if (i != null) Abilities.Add(new Ability(i.Name, i.RequiredLevel, i.IsApplied));
                }
            }
            Class = character.GetType().Name;
        }

        public CharacterDb(string id, Character character)
        {
            Id = id;
            Name = character.Name ?? character.GetType().Name;
            Strength = character.Strength;
            Dexterity = character.Dexterity;
            Constitution = character.Constitution;
            Intelligence = character.Intelligence;
            AvailableSkillPoints = character.AvailableSkillPoints;
            Experience = character.Experience;
            Inventory = character.Inventory;

            Abilities = new List<Ability?>();
            if (character.Abilities != null)
                foreach (var i in character.Abilities)
                {
                    if (i != null)
                    {
                        Abilities.Add(new Ability(i.Name, i.RequiredLevel, i.IsApplied));
                    }
                }
            Class = character.GetType().Name;
        }
    }
}
