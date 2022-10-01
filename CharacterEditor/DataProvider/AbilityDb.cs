using Editor.Core;
using Editor.Core.Abilities;
using MongoDB.Bson.Serialization.Attributes;

namespace DataProvider
{
    public class AbilityDb
    {
        [BsonId]
        public string Id { get; set; }
        public string? Name { get; set; }
        public int RequiredLevel { get; set; }

        public AbilityDb(string id, string? name, int requiredLevel)
        {
            Id = id;
            Name = name;
            RequiredLevel = requiredLevel;
        }

        public AbilityDb(string id, Ability ability)
        {
            Id = id;
            Name = ability.Name;
            RequiredLevel = ability.RequiredLevel;
        }
    }
}
