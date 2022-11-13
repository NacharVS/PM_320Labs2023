using Core.Entities.Documents;
using Core.Entities.Projects;
using Core.Entities.Users;
using DataProvider;

namespace Web.Modules;

public partial class Module
{
    private void RegisterProviders()
    {
        _builder.Services.AddSingleton<MongoProvider<BaseUser>>();
        _builder.Services.AddSingleton<MongoProvider<Customer>>();
        _builder.Services.AddSingleton<MongoProvider<Builder>>();
        _builder.Services.AddSingleton<MongoProvider<Architect>>();
        _builder.Services.AddSingleton<MongoProvider<BaseProject>>();
        _builder.Services.AddSingleton<MongoProvider<BaseDocument>>();
        _builder.Services.AddSingleton<MongoProvider<GasificationDocument>>();
        _builder.Services.AddSingleton<MongoProvider<WaterSupplyDocument>>();
    }
}