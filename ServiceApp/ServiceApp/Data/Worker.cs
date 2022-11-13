using ServiceApp.Services;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ServiceApp.Data;

public class Worker
{
    [BsonId]
    [BsonIgnoreIfDefault]
    public ObjectId Id { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? Role { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? Login { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? Password { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? PasswordRepeat { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? Surname { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? Name { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull] 
    public string? Patronymic { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull] 
    public string? EMail { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull] 
    public string? Telephone { get; set; }
    [BsonIgnoreIfDefault]
    [BsonIgnoreIfNull]
    public string? WorkerRole { get; set; }
}