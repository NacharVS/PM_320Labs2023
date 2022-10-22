using AuthorizationApp.Data;

namespace AuthorizationApp.Services;

public class UserIdentityService : IUserIdentityService
{
    public User? CurrentUser { get; set; }
}