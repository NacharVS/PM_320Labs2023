

using Users.Module;

namespace Users.Services
{
    public class UserService
    {
        string[] names = new string[]
        {
            "Oleg", "Vadim", "Bulat", "Insaf", "Constantin", "Erapolk", "Olesa", "Eva", "Hope", "Maria"
        };

        public Task<List<User>> GetUsers()
        {
            List<User> users = new List<User>();
            for (int i = 0; i < Random.Shared.Next(1, 10); i++)
            {
                users.Add(new User() 
                {
                    Name = names[Random.Shared.Next(1, 10)],
                    Id = GenerateId(),
                });
            }

            return Task.FromResult(users);
        }
        private string GenerateId()
        {
            var chars = new List<char>();

            for (var i = 0; i < Random.Shared.Next(3, 12); ++i)
            {
                chars.Add((char)Random.Shared.Next(65, 120));
            }

            return String.Concat(chars);
        }
    }
}
