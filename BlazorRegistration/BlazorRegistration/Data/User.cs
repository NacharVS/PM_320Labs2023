using BlazorRegistration.Shared;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorRegistration.Data;

public class User
{
    [BsonId]
    public int Id { get; set; }
    [BsonIgnoreIfDefault]
    public string Login { get; set; }
    [BsonIgnoreIfDefault]
    public int Password { get; set; }
    [BsonIgnoreIfDefault]
    public int PasswordRepeat { get; set; }
    [BsonIgnoreIfDefault]
    public string Surname { get; set; }
    [BsonIgnoreIfDefault]
    public string Name { get; set; }
    [BsonIgnoreIfDefault]
    public string EMail { get; set; }

    public User(string login, int password, int passwordRepeat, string surname, string name, string eMail)
    {
        Login = login;
        Password = password;
        PasswordRepeat = passwordRepeat;
        Surname = surname;
        Name = name;
        EMail = eMail;
    }
}