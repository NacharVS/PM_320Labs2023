using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ServiceApp.Data;

public class Document : Project
{
    [BsonId]
    [BsonIgnoreIfDefault]
    public ObjectId Id { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? Name { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public bool? IsApproved { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public bool? IsRequired { get; set; }

    /*public Document(bool isApproved, bool isRequired)
    {
        IsApproved = isApproved;
        IsRequired = isRequired;
    }*/
}