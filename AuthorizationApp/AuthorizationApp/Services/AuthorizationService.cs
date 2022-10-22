using AuthorizationApp.Data;
using AuthorizationApp.Database;

namespace AuthorizationApp.Services;

public class AuthorizationService : IAuthorizationService
{
    private readonly IUserRepository _repository;
    private readonly IPasswordEncryptionService _encryptionService;
    private readonly IUserIdentityService _identityService;

    public AuthorizationService(IUserRepository repository, IPasswordEncryptionService encryptionService,
        IUserIdentityService identityService)
    {
        _repository = repository;
        _encryptionService = encryptionService;
        _identityService = identityService;
    }

    public bool Register(User user)
    {
        if (_repository.IsUserRegistered(user.Login))
        {
            return false;
        }

        return _repository.CreateUser(user);
    }

    public bool Authorize(LoginCredentials loginCredentials)
    {
        if (!_repository.IsUserRegistered(loginCredentials.Login))
        {
            return false;
        }

        var password = _repository.GetEncryptedPasswordByLogin(loginCredentials.Login);
        if (!_encryptionService.EncryptPassword(loginCredentials.Password).SequenceEqual(password))
            return false;
        AuthorizedUsersCounter.AuthorizedUsersCount++;
        _identityService.CurrentUser = _repository.GetUser(loginCredentials.Login);
        return true;
    }

    public void Logout()
    {
        _identityService.CurrentUser = null;
    }
}