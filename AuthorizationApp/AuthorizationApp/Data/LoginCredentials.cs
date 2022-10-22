namespace AuthorizationApp.Data;

public record LoginCredentials
{
    public string Login { get; set; }
    public string Password { get; set; }
}