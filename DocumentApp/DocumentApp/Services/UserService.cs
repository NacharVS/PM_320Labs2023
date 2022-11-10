using DocumentApp.Interfaces;
using DocumentApp.Models;
using DocumentApp;

namespace DocumentApp.Services;

public class UserService : IUserService
{
    private ILogger<UserService> _logger;

    public UserService(ILogger<UserService> logger)
    {
        _logger = logger;
    }

    public bool SaveUser(User user)
    {
        try
        {
            DataBaseConnection.UsersCollection.InsertOne(user);
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e.ToString());
            return false;
        }
    }

    public User UserLogIn(string login, string password)
    {
        var user = new User();
        return user;
    }
}