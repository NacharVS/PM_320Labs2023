using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DocumentApp.Models;

public class Form
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public List<FormField>? FormFields { get; set; } = new();
}