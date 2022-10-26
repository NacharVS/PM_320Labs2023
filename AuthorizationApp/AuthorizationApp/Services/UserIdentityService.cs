using System.IdentityModel.Tokens.Jwt;
using AuthorizationApp.Data;
using AuthorizationApp.Database;

namespace AuthorizationApp.Services;

public class UserIdentityService : IUserIdentityService
{
    private readonly IEncryptionService _encryptionService;
    private readonly IUserRepository _userRepository;
    private readonly ILocalStorageService _localStorageService;

    public UserIdentityService(ILocalStorageService localStorageService, IUserRepository userRepository, IEncryptionService encryptionService)
    {
        _localStorageService = localStorageService;
        _userRepository = userRepository;
        _encryptionService = encryptionService;
    }

    public User? CurrentUser { get; private set; }

    public async Task<bool> TrySetCurrentUser(string login)
    {
        var jwt = _encryptionService.GetJwtForUser(login);
        await _localStorageService.SetStringAsync(LocalStorageKeys.Authorization, jwt);
        CurrentUser = _userRepository.GetUser(login);

        return true;
    }

    public async Task<bool> TryGetCurrentUser()
    {
        var jwt = await _localStorageService.GetStringAsync(LocalStorageKeys.Authorization);
        if (jwt is null)
            return false;
        var handler = new JwtSecurityTokenHandler();
        var jwtSecurityToken = handler.ReadJwtToken(jwt);

        CurrentUser = _userRepository.GetUser(jwtSecurityToken.Audiences.First());
        return true;
    }

    public async Task Logout()
    {
        await _localStorageService.RemoveAsync(LocalStorageKeys.Authorization);
        CurrentUser = null;
    }
}