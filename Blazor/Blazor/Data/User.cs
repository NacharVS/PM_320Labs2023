using BlazorRegistration.Shared;

namespace BlazorRegistration.Data;

public class User
{
    public string Login { get; set; }
    public int Password { get; set; }
    public int PasswordRepeat { get; set; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Mail { get; set; }
}