var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

IDictionary<int, string> countries = new Dictionary<int, string>();

countries.Add(1, "United States");
countries.Add(2, "Canada");
countries.Add(3, "United Kingdom");
countries.Add(4, "India");
countries.Add(5, "Japan");

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("countries", async context =>
    {
        context.Response.StatusCode = 200;
        foreach(KeyValuePair<int, string> kvp in countries)
        await context.Response.WriteAsync($"{kvp.Key}, {kvp.Value}\n");
    });

    endpoints.MapGet("countries/{countryid:int:range(1, 100)}", async context =>
    {
        context.Response.StatusCode = 200;
        int countryid = Convert.ToInt32(context.Request.RouteValues["countryid"]);
        string countryname = string.Empty;
        if (countryid > 0 && countryid < 6)
        {
            countryname = countries[countryid];
        }


        if (countryid > 5 && countryid <= 100)
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync("[No Country]\n");
        }
        else if (countryid > 100 || countryid < 1)
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("The CountryID should be between 1 and 100"); 
        }
        else
        {
            await context.Response.WriteAsync($"{countryname}\n");
        }
    });

    endpoints.MapGet("countries/{countryid:int:min(101)}", async context =>
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("The CountryID should be between 1 and 100");
    });

    endpoints.MapGet("countries/{countryid:int:max(0)}", async context =>
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("The CountryID should be between 1 and 100");
    });

});


app.Run(async context =>
{
    await context.Response.WriteAsync("Welcome");
});

app.Run();
