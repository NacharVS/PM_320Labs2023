using AuthorizationApp.Data;
using AuthorizationApp.Database;

namespace AuthorizationApp.Services;

public class AuthorizationService : IAuthorizationService
{
    private readonly IUserRepository _repository;
    private readonly IPasswordEncryptionService _encryptionService;

    public AuthorizationService(IUserRepository repository, IPasswordEncryptionService encryptionService)
    {
        _repository = repository;
        _encryptionService = encryptionService;
    }

    public bool Register(User user)
    {
        return _repository.CreateUser(user);
    }

    public bool Authorize(LoginCredentials loginCredentials)
    {
        var password = _repository.GetEncryptedPasswordByLogin(loginCredentials.Login);
        if (!_encryptionService.EncryptPassword(loginCredentials.Password).Equals(password))
            return false;
        return true;
    }
}