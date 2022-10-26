using AuthorizationApp.Data;

namespace AuthorizationApp.Services;

public interface IUserIdentityService
{
    public User? CurrentUser { get; }
    public Task<bool> TrySetCurrentUser(string login);
    public Task<bool> TryGetCurrentUser();
    public Task Logout();
}