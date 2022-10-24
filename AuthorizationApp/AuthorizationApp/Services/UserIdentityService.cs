using AuthorizationApp.Data;
using AuthorizationApp.Database;

namespace AuthorizationApp.Services;

public class UserIdentityService : IUserIdentityService
{
    private readonly ILocalStorageService _localStorageService;

    public UserIdentityService(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }

    public User? CurrentUser { get; set; }

    public async Task Logout()
    {
        await _localStorageService.RemoveAsync(LocalStorageKeys.Authorization);
    }
}