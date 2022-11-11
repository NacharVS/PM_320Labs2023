using MongoDB.Bson.Serialization.Attributes;

namespace Documents.Data
{
    public class Customer : User
    {
        [BsonIgnoreIfDefault]
        public string Name { get; set; }
        [BsonIgnoreIfDefault]
        public string Surname { get; set; }
        [BsonIgnoreIfDefault]
        public string Patronymic { get; set; }
    }
}