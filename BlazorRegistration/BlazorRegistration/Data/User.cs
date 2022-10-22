using BlazorRegistration.Shared;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorRegistration.Data;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    [BsonIgnoreIfDefault]
    public string Login { get; set; }
    [BsonIgnoreIfDefault]
    public string Password { get; set; }
    [BsonIgnoreIfDefault]
    public string PasswordRepeat { get; set; }
    [BsonIgnoreIfDefault]
    public string Surname { get; set; }
    [BsonIgnoreIfDefault]
    public string Name { get; set; }
    [BsonIgnoreIfDefault]
    public string EMail { get; set; }
}