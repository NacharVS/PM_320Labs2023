using AuthorizationApp.Data;

namespace AuthorizationApp.Services;

public interface IUserIdentityService
{
    public User? CurrentUser { get; set; }
    public Task Logout();
}