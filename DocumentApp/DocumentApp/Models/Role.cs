using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DocumentApp.Models;

public class Role
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    [BsonIgnoreIfNull]
    public string? Name { get; set; }

    public override string ToString()
    {
        return Name;
    }
}