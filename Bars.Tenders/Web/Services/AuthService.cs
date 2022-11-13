using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Core.Entities.Users;
using Core.Enums;
using DataProvider;

namespace Web.Services;

public class AuthService
{
    private readonly HMACSHA256 _encryptor;
    private readonly MongoProvider<BaseUser> _userContext;
    private readonly UserDomainService _userDomain;

    public BaseUser? AuthorizedUser { get; set; }

    public AuthService(IConfiguration configuration, MongoProvider<BaseUser> userContext,
        UserDomainService userDomain)
    {
        _userContext = userContext;
        _userDomain = userDomain;
        _encryptor = new HMACSHA256(
            Encoding.UTF8.GetBytes(configuration["Encryption:AnalogKey"] ?? String.Empty));
    }
    
    public async Task<IResult> AuthorizeUser(string login, string password)
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

        if (possibleUser.PasswordHash == CalculateHash(password))
        {
            AuthorizedUser = await _userDomain.LoadUser(possibleUser._id, possibleUser.Role, true);
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

    private string CalculateHash(string password)
    {
        return Encoding.UTF8.GetString(
            _encryptor.ComputeHash(Encoding.UTF8.GetBytes(password))
        );
    }

    private bool CheckEmail(string email)
    {
        return Regex.IsMatch(email, @".+\@.+\..+");
    }

    private bool CheckPhoneNumber(string phoneNumber)
    {
        return Regex.IsMatch(phoneNumber, "^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$");
    }
}