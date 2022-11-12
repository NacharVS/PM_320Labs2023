using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ServiceApp.Data
{
    public class Project
    {
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        public string Name { get; set; }

        public string Department { get; set; }

        public string Customer { get; set; }
        public string Developer { get; set; }
        public string Designer { get; set; }
        public Dictionary<string, bool> DocsPreor { get; set; }
    }
}
