namespace AuthorizationApp.Services;

public interface IPasswordEncryptionService
{
    public byte[] EncryptPassword(string password);
}