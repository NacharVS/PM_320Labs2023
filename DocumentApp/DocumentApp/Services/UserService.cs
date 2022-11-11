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

    public bool CheckUserEx(string login)
    {
        return DataBaseConnection.UsersCollection.Find<User>(x => x.Login == login).FirstOrDefault() != null;
    }

    public User UserLogIn(string? login, string? password)
    {
        try
        {
            var res = DataBaseConnection.UsersCollection.Find<User>(x =>
                                                                      x.Login == login && x.Password == password)
                .FirstOrDefault();
            CurrentUser = res;
        }
        catch (Exception e)
        {
        }

        return CurrentUser!;
    }

    public bool UpdateUser(User user, string login)
    {
        try
        {
            DataBaseConnection.UsersCollection.ReplaceOne(x => x.Login == login, user);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
