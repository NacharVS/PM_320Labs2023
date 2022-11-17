using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Core.Entities.Users;
using DataProvider;
using Microsoft.JSInterop;

namespace Web.Services;

public class AuthService
{
    private readonly IJSRuntime _js;
    private readonly HMACSHA256 _encryptor;
    private readonly MongoProvider<BaseUser> _userContext;
    private readonly UserDomainService _userDomain;

    public BaseUser? AuthorizedUser { get; set; }

    public AuthService(IConfiguration configuration, MongoProvider<BaseUser> userContext,
        UserDomainService userDomain, IJSRuntime js)
    {
        _userContext = userContext;
        _userDomain = userDomain;
        _js = js;
        _encryptor = new HMACSHA256(
            Encoding.UTF8.GetBytes(configuration["Encryption:AnalogKey"] ?? String.Empty));
    }

    public async Task AuthorizeUserWithCache()
    {
        string login = await _js.InvokeAsync<string>("GetLogin");
        string passHash = await _js.InvokeAsync<string>("GetPasswordHash");
        try
        {
            await AuthorizeUser(login, passHash, true);
        }
        catch
        {
            // ignored
        }
    }

    public async Task<IResult> AuthorizeUser(string login, string password, bool usingHash = false)
    {
        if (login == String.Empty)
        {
            throw new Exception("Login cannot be empty");
        }
        
        if (password == String.Empty)
        {
            throw new Exception("Password cannot be empty");
        }

        var users = await _userContext.LoadAll();
        var possibleUser = users.FirstOrDefault(x => x?.Login == login);

        if (possibleUser == null)
        {
            throw new Exception("User not found");
        }

        if (possibleUser.PasswordHash == (usingHash ? password : CalculateHash(password)))
        {
            AuthorizedUser = await _userDomain.LoadUser(possibleUser._id, possibleUser.Role, true);
            if (!usingHash)
            {
                await _js.InvokeVoidAsync("AddUserToLocalStorage", login, CalculateHash(password));
            }
            return Results.Ok("Authorized");
        }

        throw new Exception("Incorrect password given");
    }

    public async Task<IResult> RegisterUser(BaseUser user, string password)
    {
        if (user.Name == String.Empty)
        {
            throw new Exception("Name cannot be empty");
        }
        
        if (user.Login == String.Empty)
        {
            throw new Exception("Login cannot be empty");
        }
        
        if (user.Email == String.Empty)
        {
            throw new Exception("Email cannot be empty");
        }
        
        if (password == String.Empty)
        {
            throw new Exception("Password cannot be empty");
        }

        if (!CheckEmail(user.Email))
        {
            throw new Exception("Email is incorrect");
        }

        if (!CheckPhoneNumber(user.PhoneNumber!))
        {
            throw new Exception("Phone number is incorrect");
        }

        user.PasswordHash = CalculateHash(password);
        await _userContext.Save(user);
        await AuthorizeUser(user.Login, password);

        return Results.Ok("Successfully registered");
    }

    public async Task LogOut()
    {
        await _js.InvokeVoidAsync("ClearLocalStorage");
        AuthorizedUser = null;
    }

    private string CalculateHash(string password)
    {
        return Encoding.UTF8.GetString(
            _encryptor.ComputeHash(Encoding.UTF8.GetBytes(password))
        );
    }

    public bool CheckEmail(string email)
    {
        return Regex.IsMatch(email, @".+\@.+\..+");
    }

    public bool CheckPhoneNumber(string phoneNumber)
    {
        return Regex.IsMatch(phoneNumber, "^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$");
    }
}