using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ServiceApp.Data;

public class Document
{
    [BsonId]
    [BsonIgnoreIfDefault]
    public ObjectId Id { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? Name { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? Number { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? designerOrganization;
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? developerOrganization;
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public bool? IsApproved { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public bool? IsRequired { get; set; }
}