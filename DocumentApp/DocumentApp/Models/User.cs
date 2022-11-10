using MongoDB.Bson.Serialization.Attributes;

namespace DocumentApp.Models;

public class User
{
    [BsonId]
    [BsonIgnoreIfNull]
    public string? Login { get; set; }
    
    [BsonIgnoreIfNull]
    public string? Password { get; set; }
    
    [BsonIgnoreIfNull]
    public string? Surname { get; set; }
    
    [BsonIgnoreIfNull]
    public string? Name { get; set; }
    
    [BsonIgnoreIfNull]
    public string? Patronymic { get; set; }
    
    [BsonIgnoreIfNull]
    public string? Email { get; set; }
    
    [BsonIgnoreIfNull]
    public string? Phone { get; set; }
    
    [BsonIgnoreIfNull]
    public string? RoleId { get; set; }
}