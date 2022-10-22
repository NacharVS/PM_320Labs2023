using MongoDB.Bson;

namespace Authorization.Data;

public class User
{
    public ObjectId Id { get; set; }
    public string FName { get; set; }
    public string LName { get; set; }
    public string Mail { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public bool IsOnline { get; set; }

    public User(string fName, string lName, string mail, string login, string password)
    {
        FName = fName;
        LName = lName;
        Mail = mail;
        Login = login;
        Password = password;
    }
}