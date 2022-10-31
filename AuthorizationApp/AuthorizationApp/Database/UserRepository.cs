﻿using AuthorizationApp.Data;
using MongoDB.Driver;

namespace AuthorizationApp.Database;

public class UserRepository : IUserRepository
{
    private readonly IMongoCollection<UserDb> _users;

    public UserRepository(MongoConnection connection)
    {
        _users = connection.Database?.GetCollection<UserDb>("Users")!;
    }

    public User GetUser(string login)
    {
        var res = _users.Find(x => x.Login == login).FirstOrDefault();
        return new User { Email = res.Email, Login = res.Login, Name = res.Name, Surname = res.Surname };
    }

    public async Task<bool> CreateUser(User user)
    {
        if (user.Password is null)
            return false;

        await _users.InsertOneAsync(new UserDb
        {
            Email = user.Email, Login = user.Login, Name = user.Name, Password = user.Password, Surname = user.Surname
        });
        return true;
    }

    public byte[] GetEncryptedPasswordByLogin(string login)
    {
        return _users.Find(x => x.Login == login).FirstOrDefault().Password;
    }

    public bool IsUserRegistered(string login)
    {
        return _users.Find(x => x.Login == login).FirstOrDefault() is not null;
    }

    public IEnumerable<User> GetLoggedUsers()
    {
        return _users.Find(x => true).ToEnumerable().Select(x => new User
            { Email = x.Email, Login = x.Login, Name = x.Name, Surname = x.Surname });
    }
}