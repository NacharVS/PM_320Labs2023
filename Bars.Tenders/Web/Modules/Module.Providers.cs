using Core.Entities.users;
using DataProvider;

namespace Web.Modules;

public partial class Module
{
    private void RegisterProviders()
    {
        _builder.Services.AddSingleton<MongoProvider<User>>();
        _builder.Services.AddSingleton<MongoProvider<Customer>>();
        _builder.Services.AddSingleton<MongoProvider<Builder>>();
        _builder.Services.AddSingleton<MongoProvider<Architect>>();
    }
}