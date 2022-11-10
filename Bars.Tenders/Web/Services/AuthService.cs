using System.Security.Cryptography;
using System.Text;
using Core.Entities.users;
using Core.Enums;
using DataProvider;

namespace Web.Services;

public class AuthService
{
    private readonly HMACSHA256 _encryptor;
    private readonly IConfiguration _configuration;
    
    private readonly MongoProvider<User> _userContext;
    private readonly MongoProvider<Customer> _customerContext;
    private readonly MongoProvider<Builder> _builderContext;
    private readonly MongoProvider<Architect> _architectContext;

    public User? AuthorizedUser { get; set; }

    public AuthService(IConfiguration configuration, MongoProvider<User> userContext,
        MongoProvider<Customer> customerContext, MongoProvider<Builder> builderContext,
        MongoProvider<Architect> architectContext)
    {
        _userContext = userContext;
        _customerContext = customerContext;
        _builderContext = builderContext;
        _architectContext = architectContext;
        
        _configuration = configuration;
        _encryptor = new HMACSHA256(
            Encoding.UTF8.GetBytes(configuration["Encryption:AnalogKey"] ?? String.Empty));
    }
    
    public async Task<IResult> AuthorizeUser(string email, string password)
    {
        var users = await _userContext.LoadAll();
        var possibleUser = users.FirstOrDefault(x => x?.Email == email);

        if (possibleUser == null)
        {
            return Results.Json(new { message = "User not found" }, statusCode: 400);
        }

        if (possibleUser.PasswordHash == CalculateHash(password))
        {
            AuthorizedUser = possibleUser;
            return Results.Ok("Authorized");
        }

        return Results.Json(new { message = "Incorrect password given" },
            statusCode: 400
        );
    }

    public async Task RegisterUser(User user, string password)
    {
        switch (user.Role)
        {
            case UserRole.Customer:
                await _customerContext.Save(user as Customer ?? new Customer());
                break;
            case UserRole.Builder:
                await _builderContext.Save(user as Builder ?? new Builder());
                break;
            case UserRole.Architect:
                await _architectContext.Save(user as Architect ?? new Architect());
                break;
            default:
                throw new Exception("Role is not specified!");
        }

        user.PasswordHash = CalculateHash(password);
        await _userContext.Save(user);
        await AuthorizeUser(user.Email, password);
    }

    public string CalculateHash(string password)
    {
        return Encoding.UTF8.GetString(
            _encryptor.ComputeHash(Encoding.UTF8.GetBytes(password))
        );
    }
}