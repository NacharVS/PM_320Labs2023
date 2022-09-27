using CharacterEditorCore;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CharacterEditorMongoDb
{
    public class CharacterDb
    {
        [BsonIgnoreIfDefault]
        public ObjectId _id;
        [BsonIgnoreIfNull]
        public string Name { get; set; }
        [BsonIgnoreIfNull]
        public string ClassName { get; set; }
        [BsonIgnoreIfDefault]
        public int Strength { get; set; }
        [BsonIgnoreIfDefault]
        public int Dexterity { get; set; }
        [BsonIgnoreIfDefault]
        public int Constitution { get; set; }
        [BsonIgnoreIfDefault]
        public int Intellisense { get; set; }
        [BsonIgnoreIfNull]
        public List<IItem> Items { get; set; }

        public CharacterDb(string name, string className, 
                            int strength, int dexterity, 
                            int constitution, int intellisense,
                            List<IItem> items)
        {
            Name = name;
            ClassName = className;
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intellisense = intellisense;
            Items = items;
        }
    }
}