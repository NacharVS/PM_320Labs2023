using MongoDB.Bson.Serialization.Attributes;

namespace DocumentApp.Models;

public class Customer : User
{
    [BsonIgnoreIfNull]
    public string? Surname { get; set; }
    
    [BsonIgnoreIfNull]
    public string? Name { get; set; }
    
    [BsonIgnoreIfNull]
    public string? Patronymic { get; set; }
 
    [BsonIgnoreIfNull]
    public string? Department { get; set; }
}