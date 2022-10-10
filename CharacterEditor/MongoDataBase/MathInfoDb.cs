
using CharacterEditorCore;
using MongoDB.Bson.Serialization.Attributes;

namespace CharacterEditorMongoDataBase
{
    public class MathInfoDb
    {
        [BsonIgnoreIfNull]
        public List<CharacterIdName> FirstTeam { get; set; }
        [BsonIgnoreIfNull]
        public List<CharacterIdName> SecondTeam { get; set; }
        public DateTime Time { get; set; }
    }
}
