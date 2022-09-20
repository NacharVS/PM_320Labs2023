using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CharacterEditorCore
{
    public class BaseCharacterrDb
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonIgnoreIfNull]
        public string? Name { get; set; }
        [BsonIgnoreIfNull]
        public string? CharacterClassName { get; set; }

        [BsonIgnoreIfDefault]
        public int Strength { get; set; }
        [BsonIgnoreIfDefault]
        public int Intelligence { get; set; }

        [BsonIgnoreIfDefault] 
        public int Dexterity { get; set; }
        [BsonIgnoreIfDefault]
        public int Constitution { get; set; }


    }
}
