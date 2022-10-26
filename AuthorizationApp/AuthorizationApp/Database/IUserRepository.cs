using AuthorizationApp.Data;

namespace AuthorizationApp.Database;

public interface IUserRepository
{
    public User GetUser(string login);
    public Task<bool> CreateUser(User user);
    public byte[] GetEncryptedPasswordByLogin(string login);
    public bool IsUserRegistered(string login);
    public IEnumerable<User> GetLoggedUsers();
}