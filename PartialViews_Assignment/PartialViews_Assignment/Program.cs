var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.UseStaticFiles();
app.UseRouting();


app.Run();
