using Web.Data;
using Web.Services;

namespace Web.Modules;

public partial class Module
{
    private void RegisterServices()
    {
        _builder.Services.AddRazorPages();
        _builder.Services.AddServerSideBlazor();
        _builder.Services.AddSingleton<WeatherForecastService>();
        _builder.Services.AddScoped<AuthService>();
        _builder.Services.AddSingleton<UserDomainService>();
        _builder.Services.AddSingleton<ProjectDomainService>();
        _builder.Services.AddSingleton<DocumentDomainService>();
    }
}