using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Entities;

public class User
{
    [BsonId]
    public ObjectId _id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Login { get; set; }
    public string PasswordHash { get; set; }

    public User(string name, string surname, string email, string login, string passwordHash)
    {
        Name = name;
        Surname = surname;
        Email = email;
        Login = login;
        PasswordHash = passwordHash;
        
        _id = ObjectId.GenerateNewId();
    }
}