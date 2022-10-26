using BlazorRegistration.Shared;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorRegistration.Data;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonIgnoreIfDefault]
    public string? Id { get; set; }
    [BsonIgnoreIfNull]
    public string Login { get; set; }
    [BsonIgnoreIfNull]
    public string Password { get; set; }
    [BsonIgnoreIfNull]
    public string PasswordRepeat { get; set; }
    [BsonIgnoreIfNull]
    public string Surname { get; set; }
    [BsonIgnoreIfNull]
    public string Name { get; set; }
    [BsonIgnoreIfNull]
    public string EMail { get; set; }
}