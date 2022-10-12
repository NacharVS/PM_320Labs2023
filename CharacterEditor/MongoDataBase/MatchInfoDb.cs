
using CharacterEditorCore;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CharacterEditorMongoDataBase
{
    public class MatchInfoDb
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string? Id { get; set; }
        [BsonIgnoreIfNull]
        public List<CharacterIdName> FirstTeam { get; set; }
        [BsonIgnoreIfNull]
        public List<CharacterIdName> SecondTeam { get; set; }
        [BsonIgnoreIfNull]
        public DateTime Time { get; set; }
    }
}
