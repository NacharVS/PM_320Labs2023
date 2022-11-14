using MongoDB.Bson;

namespace Tenders.Data.Users;

public class User
{
    public ObjectId Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public User(string login, string password, string email, string phoneNumber)
    {
        Login = login;
        Password = password;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public User() { }

    public User(UserModel model)
    {
        Id = model.Id;
        Login = model.Login;
        Password = model.Password;
        Email = model.Email;
        PhoneNumber = model.PhoneNumber;
    }
}