using MongoDB.Bson.Serialization.Attributes;

namespace Documents.Data
{
    public class Builder : User
    {
        [BsonIgnoreIfDefault]
        public string Name { get; set; }
        [BsonIgnoreIfDefault]
        public string OGRN { get; set; }
        [BsonIgnoreIfDefault]
        public string INN { get; set; }
        [BsonIgnoreIfDefault]
        public string KPP { get; set; }
        [BsonIgnoreIfDefault]
        public string Address { get; set; }
        [BsonIgnoreIfDefault]
        public string Director { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}