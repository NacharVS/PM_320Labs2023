using Core.DataProvider;
using Core.Entities;

namespace Web.Services;

public class SessionService
{
    private User? _currentUser;
    private readonly UserService _userService;

    public SessionService(UserService userService)
    {
        _userService = userService;
    }
    
    public void SetCurrentUser(User user)
    {
        _currentUser = user;
    }

    public async Task<User?> GetCurrentUser()
    {
        return await Task.FromResult(_currentUser);
    }

    public async Task<User?> AuthorizeUser(string login, string password)
    {
        var savedUser = await Database.GetUser(login);

        if (savedUser == null || savedUser.PasswordHash != password)
        {
            return null;
        }

        _currentUser = savedUser;
        _userService.UpdateAuthorizedUsers(_currentUser);
        return savedUser;
    }

    public Task LogOut()
    {
        _currentUser = null;
        _userService.UpdateAuthorizedUsers(_currentUser, true);
        return Task.CompletedTask;
    }
}