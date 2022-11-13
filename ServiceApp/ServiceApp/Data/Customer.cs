using MongoDB.Bson.Serialization.Attributes;

namespace ServiceApp.Data;

public class Customer : Worker
{
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? Department { get; set; }
}