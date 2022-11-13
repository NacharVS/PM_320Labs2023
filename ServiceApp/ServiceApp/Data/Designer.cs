using MongoDB.Bson.Serialization.Attributes;

namespace ServiceApp.Data;

public class Designer : Worker
{
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? ProjectOrganizationName { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? OGRN { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? INN { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? KPP { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? Adress { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? Director { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? ChiefProjectEngineer { get; set; }
}