using System.Security.Cryptography;
using System.Text;

namespace AuthorizationApp.Services;

public class PasswordEncryptionService : IPasswordEncryptionService
{
    private readonly HMACSHA256 _encryptor;

    public PasswordEncryptionService(IConfiguration configuration)
    {
        _encryptor = new HMACSHA256(
            Encoding.UTF8.GetBytes(configuration["Encryption:AnalogKey"]));
    }

    public byte[] EncryptPassword(string password)
    {
        return _encryptor.ComputeHash(Encoding.UTF8.GetBytes(password));
    }
}