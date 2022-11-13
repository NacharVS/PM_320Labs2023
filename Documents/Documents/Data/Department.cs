using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Documents.Data
{
    public class Department
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string? Id { get; set; }

        [BsonIgnoreIfDefault]
        public string? Name { get; set; }
    }
}
