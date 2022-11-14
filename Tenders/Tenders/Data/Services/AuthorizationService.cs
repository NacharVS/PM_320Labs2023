using System.Text.RegularExpressions;
using Authorization.Data;
using Tenders.Data.Users;

namespace Tenders.Data.Services;

public class AuthorizationService
{
    public User CurrentUser;
    public ILocalStorageService LocalStorageService;
    
    public AuthorizationService(ILocalStorageService localStorageService)
    {
        LocalStorageService = localStorageService;
    }

    public string LogIn(User user)
    {
        if (String.IsNullOrEmpty(user.Login) || String.IsNullOrEmpty(user.Password))
        {
            return "Not all fields are written!";
        }

        var foundedUser = MongoConnectionService.FindUser(user.Login, user.Password);

        if(foundedUser == null)
        {
            return "Not correct login or password";
        }

        if (foundedUser.Role == UserRole.Customer)
        {
            CurrentUser = new Customer(foundedUser);
        }
        else if (foundedUser.Role == UserRole.Designer)
        {
            CurrentUser = new Designer(foundedUser);
        }
        else if (foundedUser.Role == UserRole.Developer)
        {
            CurrentUser = new Developer(foundedUser);
        }

        LocalStorageService.SetStringAsync("key", user.Login);
        return "";
    }

    public void Exit()
    {
        LocalStorageService.RemoveAsync("key");
    }
    
    public string Registrate(User? user, string repeatedPassword, UserRole role)
    {
        if (user.Password != repeatedPassword)
        {
            return "Passwords don't match";
        }
        if (string.IsNullOrEmpty(user.PhoneNumber) || string.IsNullOrEmpty(user.Email) || 
            string.IsNullOrEmpty(user.Login) || string.IsNullOrEmpty(user.Password) || role == UserRole.Uncpecified)
        {
            return "Not all fields are filled in";
        }

        if (!Regex.IsMatch(user.Email, @".+\@.+\..+"))
        {
            return "Not correct email";
        }

        if (!Regex.IsMatch(user.PhoneNumber, "^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$"))
        {
            return "Not correct phone number";
        }
        
        if (MongoConnectionService.FindByLogin(user.Login) != null)
        {
            return "This login is taken";
        }

        if (role == UserRole.Customer)
        {
            user = new Customer(user);
        }
        else if (role == UserRole.Designer)
        {
            user = new Designer(user);
        }
        else if (role == UserRole.Developer)
        {
            user = new Developer(user);
        }
        MongoConnectionService.AddToDb(user);
        return "";
    }

    public async Task GetLocalUser()
    {
        string newUserLogin = await LocalStorageService.GetStringAsync("key");

        if (String.IsNullOrEmpty(newUserLogin))
            return;
                
        var model = MongoConnectionService.FindByLogin(newUserLogin);

        if (model.Role == UserRole.Customer)
        {
            CurrentUser = new Customer(model);
        }
        else if (model.Role == UserRole.Designer)
        {
            CurrentUser = new Designer(model);
        }
        else if (model.Role == UserRole.Developer)
        {
            CurrentUser = new Developer(model);
        }
    }
}