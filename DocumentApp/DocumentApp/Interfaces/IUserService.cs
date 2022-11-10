using DocumentApp.Models;

namespace DocumentApp.Interfaces;

public interface IUserService
{
    public bool SaveUser(User user);
    public User UserLogIn(string login, string password);
}