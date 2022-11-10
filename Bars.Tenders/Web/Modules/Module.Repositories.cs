using Core.Entities.users;
using DataProvider.Domain;
using DataProvider.Domain.Impl;

namespace Web.Modules;

public partial class Module
{
    private void RegisterRepositories()
    {
        _builder.Services.AddSingleton<IRepository<User>, BaseRepository<User>>();
        _builder.Services.AddSingleton<IRepository<Customer>, BaseRepository<Customer>>();
        _builder.Services.AddSingleton<IRepository<Builder>, BaseRepository<Builder>>();
        _builder.Services.AddSingleton<IRepository<Architect>, BaseRepository<Architect>>();
    }
}