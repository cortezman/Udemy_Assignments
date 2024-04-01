using ServiceContracts;
using Services;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IWeatherService, WeatherService>();

builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();
app.UseRouting();

app.Run();
