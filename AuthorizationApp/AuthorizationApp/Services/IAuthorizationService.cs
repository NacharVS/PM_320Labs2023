using AuthorizationApp.Data;

namespace AuthorizationApp.Services;

public interface IAuthorizationService
{
    public bool Register(User user);
    public bool Authorize(LoginCredentials loginCredentials);
    public void Logout();
}