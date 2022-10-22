using AuthorizationApp.Data;

namespace AuthorizationApp.Services;

public interface IAuthorizationService
{
    public IEnumerable<User> GetLoggedUsers();
    public bool Register(User user);
    public bool Authorize(LoginCredentials loginCredentials);
    public void Logout();
}