using UsersFetcher.Models;

namespace UsersFetcher.Services;

public class UserService
{
    public Task<User[]> GetUsers()
    {
        return Task.FromResult(Enumerable.Range(1, 1).Select(_ => new User
        {
            Age = Random.Shared.Next(14, 60),
            Login = GenerateLogin()
        }).ToArray());
    }

    private string GenerateLogin()
    {
        var chars = new List<char>();

        for (var i = 0; i < Random.Shared.Next(3, 12); ++i)
        {
            chars.Add((char)Random.Shared.Next(65, 120));
        }

        return String.Concat(chars);
    }
}