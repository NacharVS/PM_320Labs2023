using AuthorizationApp.Data;
using AuthorizationApp.Database;

namespace AuthorizationApp.Services;

public class AuthorizationService : IAuthorizationService
{
    private readonly IUserRepository _repository;
    private readonly IEncryptionService _encryptionService;
    private readonly IUserIdentityService _identityService;

    public AuthorizationService(IUserRepository repository, IEncryptionService encryptionService,
        IUserIdentityService identityService)
    {
        _repository = repository;
        _encryptionService = encryptionService;
        _identityService = identityService;
    }

    public IEnumerable<User> GetLoggedUsers()
    {
        return _repository.GetLoggedUsers();
    }

    public async Task<bool> Register(User user)
    {
        if (_repository.IsUserRegistered(user.Login))
        {
            return false;
        }

        return await _repository.CreateUser(user);
    }

    public async Task<bool> Authorize(LoginCredentials loginCredentials)
    {
        if (!_repository.IsUserRegistered(loginCredentials.Login))
        {
            return false;
        }

        var password = _repository.GetEncryptedPasswordByLogin(loginCredentials.Login);
        if (!_encryptionService.EncryptPassword(loginCredentials.Password).SequenceEqual(password))
            return false;
        var res = await _identityService.TrySetCurrentUser(loginCredentials.Login);
        return res;
    }

    public async Task Logout()
    {
        await _identityService.Logout();
    }
}