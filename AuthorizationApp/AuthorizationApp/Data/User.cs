namespace AuthorizationApp.Data;

public class User
{
    public string Login { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public byte[]? Password { get; set; }
}