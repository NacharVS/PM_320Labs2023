using Core.Entities.users;
using DataProvider;

namespace Web.Modules;

public partial class Module
{
    private void RegisterConnections()
    {
        _builder.Services.AddSingleton<MongoConnection<User>>();
        _builder.Services.AddSingleton<MongoConnection<Customer>>();
        _builder.Services.AddSingleton<MongoConnection<Builder>>();
        _builder.Services.AddSingleton<MongoConnection<Architect>>();
    }
}