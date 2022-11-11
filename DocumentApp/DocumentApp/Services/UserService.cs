using DocumentApp.Interfaces;
using DocumentApp.Models;
using DocumentApp.Services;
using DocumentApp.Shared;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace DocumentApp.Services;

public class UserService 
{
    public User CurrentUser { get; set; }

    public UserService()
    {
        BsonClassMap.RegisterClassMap<Customer>();
        BsonClassMap.RegisterClassMap<Builder>();
        BsonClassMap.RegisterClassMap<Designer>();
    }

    public bool SaveUser(User user)
    {
        try
        {
            DataBaseConnection.UsersCollection.InsertOne(user);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public User UserLogIn(string? login, string? password)
    {
        try
        {
            var res = DataBaseConnection.UsersCollection.Find<User>(x =>
                                                                      x.Login == login && x.Password == password)
                .FirstOrDefault();
            CurrentUser = res;
            return res;
            // switch (DataBaseConnection.RolesCollection.Find(x=> x.Id == res.RoleId).FirstOrDefault().Name)
            // {
            //     case "Заказчик":
            //         CurrentUser = res as Customer ?? new Customer();
            //         _localStorageService.SetAsync<Customer>("Authorization", CurrentUser as Customer);
            //         break;
            //     case "Проектировщик":
            //         CurrentUser = res as Designer ?? new Designer();
            //         _localStorageService.SetAsync<Designer>("Authorization", CurrentUser as Designer);
            //         break;
            //     case "Застройщик":
            //         CurrentUser = res as Builder ?? new Builder();
            //         _localStorageService.SetAsync<Builder>("Authorization", CurrentUser as Builder);
            //         break;
            // }
        }
        catch (Exception e)
        {
        }

        return CurrentUser!;
    }

    public User GetUserByLoginAndPassword(string login, string password)
    {
        return DataBaseConnection.UsersCollection.Find(x =>
            x.Login == login && x.Password == password).FirstOrDefault();
    }
}
