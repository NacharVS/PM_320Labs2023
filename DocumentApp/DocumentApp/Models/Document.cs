using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DocumentApp.Models;

public class Document
{
    [BsonId] [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonIgnoreIfNull]
    public string? Name { get; set; }
    [BsonIgnoreIfNull]
    public string FileName { get; set; }
    [BsonIgnoreIfNull]
    public byte[] Data { get; set; }

    [BsonIgnoreIfNull]
    public bool IsPrefer { get; set; }
    
    [BsonIgnoreIfNull]
    public bool IsApproved { get; set; }
}