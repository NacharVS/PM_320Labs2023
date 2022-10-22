using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AuthorizationWebApp.Data;

public class User
{
    [BsonId]
    [BsonIgnoreIfNull]
    public string? Login { get; set; }
    [BsonIgnoreIfNull]
    public string? Password { get; set; }
    [BsonIgnoreIfNull]
    public string? Name { get; set; }
    [BsonIgnoreIfNull]
    public string? Surname { get; set; }
    [BsonIgnoreIfNull]
    public string? Mail { get; set; }
}