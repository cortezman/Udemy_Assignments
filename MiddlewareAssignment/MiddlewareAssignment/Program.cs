using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using MiddlewareAssignment.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
//builder.Services.AddTransient<UsernamePassword_Validation>();

app.UseUsernamePassword_Validation();

//app.MapGet("/", () => "Hello World!");
//app.Run(async (HttpContext context) =>
//{
//    string email = string.Empty, password = string.Empty, message = string.Empty;
//    StreamReader reader = new StreamReader(context.Request.Body);
//    string body = await reader.ReadToEndAsync();
//    Dictionary<string, StringValues> queryDictionary = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);
//    if (context.Request.Method =="POST" && context.Request.Path == "/")
//    {
//        if (queryDictionary.ContainsKey("email"))
//        {
//            email = queryDictionary["email"][0];
//        }

//        if (queryDictionary.ContainsKey("password"))
//        {
//            password = queryDictionary["password"][0];
//        }
//        if (!string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(password))
//        {
//            if (!string.IsNullOrEmpty(email)) 
//            {
//                if (email == "ron@gmail.com")
//                {
//                    if (password == "1234")
//                    {
//                        context.Response.StatusCode = 200;
//                        message += "successful login";
//                    }
//                    else
//                    {
//                        context.Response.StatusCode = 400;
//                        message += "Incorrect Password\n";
//                    }
//                }
//                else
//                {
//                    context.Response.StatusCode = 400;
//                    message += "Incorrect Email\n";
//                    if (!(password == "1234"))
//                    {
//                        message += "Incorrect Password\n";
//                    }
//                }
//            }
//            else
//            {
//                context.Response.StatusCode = 400;
//                message += "Incorrect Email\n";
//                if (!string.IsNullOrEmpty(password))
//                {
//                    if (!(password == "1234"))
//                    {
//                        message += "Incorrect Password\n";
//                    }
//                }
//                else
//                {
//                    message += "Incorrect Password\n";
//                }

//            }
//        }
//    }
//    else if (context.Request.Method == "GET" && context.Request.Path == "/")
//    {
//        context.Response.StatusCode = 200;
//        message = "No Response";
//    }

//});
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("\n");
});
app.Run();
