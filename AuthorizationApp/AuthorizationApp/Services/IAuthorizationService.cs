﻿using AuthorizationApp.Data;

namespace AuthorizationApp.Services;

public interface IAuthorizationService
{
    public IEnumerable<User> GetLoggedUsers();
    public Task<bool> Register(User user);
    public Task<bool> Authorize(LoginCredentials loginCredentials);
    public Task Logout();
}