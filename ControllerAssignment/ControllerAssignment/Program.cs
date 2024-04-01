var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.Map("/get-current-balance/{accountNumber:regex(^\\w)}", async context =>
    {
        await context.Response.WriteAsync("Wrong parameters");
    });
});

app.Run();
