using MongoDB.Bson.Serialization.Attributes;

namespace ServiceApp.Data;

public class Developer : Worker
{
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? DeveloperOrganizationName { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? OGRN{ get; set; }
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
    public string? ExecutiveCommitteeHead { get; set; }
}