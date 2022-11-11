using MongoDB.Bson.Serialization.Attributes;

namespace DocumentApp.Models;

public class Designer : User
{
    [BsonIgnoreIfNull]
    public string? DesignerName { get; set; }
    
    [BsonIgnoreIfNull]
    public string? OGRN { get; set; }
    
    [BsonIgnoreIfNull]
    public string? INN { get; set; }
    
    [BsonIgnoreIfNull]
    public string? KPP { get; set; }
    
    [BsonIgnoreIfNull]
    public string? Adress { get; set; }
    
    [BsonIgnoreIfNull]
    public string? Director { get; set; }
    
    [BsonIgnoreIfNull]
    public string? MainIngeneer { get; set; }
}