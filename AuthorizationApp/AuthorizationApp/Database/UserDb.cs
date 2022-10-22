using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AuthorizationApp.Database;

public record UserDb
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    [Required]
    public string Login { get; set; }
    [Required]
    public string Email { get; set; }
    [BsonIgnoreIfDefault]
    public string Name { get; set; }
    [BsonIgnoreIfDefault]
    public string Surname { get; set; }
    [Required]
    public byte[] Password { get; set; }
}