using CharacterEditorCore.Match;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CharacterEditorMongoDb
{
    public class MatchDB
    {
        [BsonIgnoreIfDefault]
        public ObjectId _id;
        [BsonIgnoreIfNull]
        public List<MatchCharacterInfo> FirstTeam { get; set; }
        [BsonIgnoreIfNull]
        public List<MatchCharacterInfo> SecondTeam { get; set; }
        [BsonIgnoreIfNull]
        public DateTime StartDate { get; set; }
    }
}
