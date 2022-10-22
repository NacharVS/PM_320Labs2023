﻿using CharacterEditorCore;
using CharacterEditorCore.Items;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CharacterEditorMongoDb
{
    public class CharacterDb
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string? Id { get; set; }
        [BsonIgnoreIfNull]
        public string Name { get; set; }
        [BsonIgnoreIfNull]
        public string ClassName { get; set; }
        [BsonIgnoreIfDefault]
        public int Experience { get; set; }
        [BsonIgnoreIfDefault]
        public int Strength { get; set; }
        [BsonIgnoreIfDefault]
        public int Dexterity { get; set; }
        [BsonIgnoreIfDefault]
        public int Constitution { get; set; }
        [BsonIgnoreIfDefault]
        public int Intellisense { get; set; }
        [BsonIgnoreIfNull]
        public List<Item> Items { get; set; }
        [BsonIgnoreIfNull]
        public List<Ability> Abilities { get; set; }
        [BsonIgnoreIfDefault]
        public int AvailableAbilityCount { get; set; }
        [BsonIgnoreIfNull]
        public Equipment Equipment { get; set; }

        public CharacterDb(string name, string className, 
                            int strength, int dexterity, 
                            int constitution, int intellisense,
                            List<Item> items, int experience,
                            List<Ability> abilities, int availableAbilityCount,
                            Equipment equipment)
        {
            Name = name;
            ClassName = className;
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intellisense = intellisense;
            Items = items;
            Experience = experience;
            Abilities = abilities;
            AvailableAbilityCount = availableAbilityCount;
            Equipment = equipment;
        }
    }
}