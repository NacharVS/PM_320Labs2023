using System;
using System.Linq;
using System.Threading.Tasks;

namespace FirstBlazorApp.Data
{
    public class UserService
    {
        private static string[] userNames = new string[]
        {"Rinat", "Bulat", "Danil", "Roman", "Dinar", "Ilyas"};

        private static string[] userSurnames = new string[]
        {"Safiullin", "Saifullin", "Abramov", "Vasilev", "Gilaev", "Giniyatullin"};

        private static string[] userEmailes = new string[]
        {"rinat@mail.ru", "bulat@mail.ru", "abram@mail.ru", "romchik@mail.ru", "dimon@mail.ru", "bezoksy@mail.ru"};

        public static User[] GetAllUsers()
        {
            var rnd = new Random();
            return Enumerable.Range(0, userNames.Length).Select(x => new User
            {
                Name = userNames[rnd.Next(0, userNames.Length)],
                Surname = userSurnames[rnd.Next(0, userSurnames.Length)],
                Email = userEmailes[rnd.Next(0, userEmailes.Length)],
                Age = rnd.Next(10, 100)
            }).ToArray();
        }

        public static User[] GetUser()
        {
            var rnd = new Random();
            return new User[] {new User
            {
                Name = userNames[rnd.Next(0, userNames.Length)],
                Surname = userSurnames[rnd.Next(0, userSurnames.Length)],
                Email = userEmailes[rnd.Next(0, userEmailes.Length)],
                Age = rnd.Next(10, 100)
            } };
        }
    }
}