using Core.DataProvider;
using Core.Entities;

namespace Web.Services;

public class UserService
{
    public List<User> AuthorizedUsers = new();
    
    public async Task<User?> GetUser(string login)
    {
        return await Database.GetUser(login);
    }

    public async Task SaveUser(User user)
    {
        await Database.SaveUser(user);
        UpdateAuthorizedUsers(user);
    }

    public void UpdateAuthorizedUsers(User user, bool remove=false)
    {
        if (remove)
        {
            AuthorizedUsers.Remove(user);
        }
        else
        {
            AuthorizedUsers.Add(user);
        }
    }
}