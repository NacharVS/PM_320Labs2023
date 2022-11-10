namespace Web.Modules;

public partial class Module
{
    private readonly WebApplicationBuilder _builder;
    
    public Module(WebApplicationBuilder builder)
    {
        _builder = builder;
    }

    public void RegisterModules()
    {
        RegisterConnections();
        RegisterRepositories();
        RegisterProviders();
    }
}