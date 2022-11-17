using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ServiceApp.Data;

public class Project
{
    [BsonId]
    [BsonIgnoreIfDefault]
    public ObjectId Id { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? Name { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? Designer { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? Developer { get; set; }

    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public List<WaterDocument> WaterDocuments { get; set; } = new List<WaterDocument>();

    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public List<GasDocument> GasDocuments { get; set; } = new List<GasDocument>();

    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public List<DesignerDocument> DesignerDocuments { get; set; } = new List<DesignerDocument>();
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? designerOrganization;
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? developerOrganization;
}