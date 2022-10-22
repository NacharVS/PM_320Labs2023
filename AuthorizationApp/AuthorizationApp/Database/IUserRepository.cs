using AuthorizationApp.Data;

namespace AuthorizationApp.Database;

public interface IUserRepository
{
    public User GetUser(string id);
    public bool CreateUser(User user);
    public byte[] GetEncryptedPasswordByLogin(string login);
}