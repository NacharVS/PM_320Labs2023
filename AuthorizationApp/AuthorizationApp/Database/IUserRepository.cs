using AuthorizationApp.Data;

namespace AuthorizationApp.Database;

public interface IUserRepository
{
    public User GetUser(string login);
    public bool CreateUser(User user);
    public byte[] GetEncryptedPasswordByLogin(string login);
    public bool IsUserRegistered(string login);
}