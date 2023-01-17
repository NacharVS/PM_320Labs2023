using AuthorizationApp;
using AuthorizationApp.Data;
using AuthorizationApp.Database;
using AuthorizationApp.Services;
using AuthorizationApp.Services.Interfaces;
using Timer = AuthorizationApp.Timer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton(_ => new MongoConnection("mongodb://localhost", "AuthorizationApp"));
builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
builder.Services.AddScoped<IUserIdentityService, UserIdentityService>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IEncryptionService, EncryptionService>();
builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();
builder.Services.AddSingleton<IFileService, FileService>();
builder.Services.AddSingleton<Timer>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddHostedService<ImageHostedService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();