using CharacterEditorCore.Match;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CharacterEditorMongoDb
{
    public class MatchDB
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string? Id { get; set; }
        [BsonIgnoreIfNull]
        public List<MatchCharacterInfo> FirstTeam { get; set; }
        [BsonIgnoreIfNull]
        public List<MatchCharacterInfo> SecondTeam { get; set; }
        [BsonIgnoreIfNull]
        public DateTime StartDate { get; set; }

        public override string? ToString()
        {
            return $"{StartDate} | {Id}";
        }
    }
}