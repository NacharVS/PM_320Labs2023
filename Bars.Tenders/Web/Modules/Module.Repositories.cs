using Core.Entities.Documents;
using Core.Entities.Projects;
using Core.Entities.Users;
using DataProvider.Domain;
using DataProvider.Domain.Impl;

namespace Web.Modules;

public partial class Module
{
    private void RegisterRepositories()
    {
        _builder.Services.AddSingleton<IRepository<BaseUser>, BaseRepository<BaseUser>>();
        _builder.Services.AddSingleton<IRepository<Customer>, BaseRepository<Customer>>();
        _builder.Services.AddSingleton<IRepository<Builder>, BaseRepository<Builder>>();
        _builder.Services.AddSingleton<IRepository<Architect>, BaseRepository<Architect>>();
        _builder.Services.AddSingleton<IRepository<BaseProject>, BaseRepository<BaseProject>>();
        _builder.Services.AddSingleton<IRepository<BaseDocument>, BaseRepository<BaseDocument>>();
        _builder.Services.AddSingleton<IRepository<WaterSupplyDocument>, BaseRepository<WaterSupplyDocument>>();
        _builder.Services.AddSingleton<IRepository<GasificationDocument>, BaseRepository<GasificationDocument>>();
    }
}