using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DocumentApp.Models;

public class Form
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    [BsonIgnoreIfNull]
    public List<FormField>? FormFields { get; set; } = new();
    
    [BsonIgnoreIfNull]
    public bool IsApproved { get; set; }
}