using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Threading.Tasks;

namespace MiddlewareAssignment.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class UsernamePassword_Validation
    {
        
        private readonly RequestDelegate _next;

        public UsernamePassword_Validation(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string email = string.Empty, password = string.Empty, message = string.Empty;
            StreamReader reader = new StreamReader(httpContext.Request.Body);
            string body = await reader.ReadToEndAsync();
            Dictionary<string, StringValues> queryDictionary = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);
            if (httpContext.Request.Method == "POST" && httpContext.Request.Path == "/")
            {
                if (queryDictionary.ContainsKey("email"))
                {
                    email = queryDictionary["email"][0];
                }
                else
                {
                    httpContext.Response.StatusCode = 400;
                    message += "Incorrect Email\n";
                }

                if (queryDictionary.ContainsKey("password"))
                {
                    password = queryDictionary["password"][0];
                }
                else
                {
                    httpContext.Response.StatusCode = 400;
                    message += "Incorrect Password\n";
                }

                if (!string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(password))
                {
                    if (!string.IsNullOrEmpty(email))
                    {
                        if (email == "ron@gmail.com")
                        {
                            if (password == "1234")
                            {
                                httpContext.Response.StatusCode = 200;
                                message += "successful login";
                            }
                            else if (!string.IsNullOrEmpty(password))
                            {
                                httpContext.Response.StatusCode = 400;
                                message += "Incorrect Password\n";
                            }
                        }
                        else
                        {
                            httpContext.Response.StatusCode = 400;
                            message += "Incorrect Email\n";
                            if (!(password == "1234"))
                            {
                                message += "Incorrect Password\n";
                            }
                        }
                    }
                    else
                    {
                        httpContext.Response.StatusCode = 400;
                        if (!string.IsNullOrEmpty(password))
                        {
                            if (!(password == "1234"))
                            {
                                message += "Incorrect Password\n";
                            }
                        }
                    }
                }
            }
            else if (httpContext.Request.Method == "GET" && httpContext.Request.Path == "/")
            {
                httpContext.Response.StatusCode = 200;
                message = "No Response";
            }
            await httpContext.Response.WriteAsync(message);

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class UsernamePassword_ValidationExtensions
    {
        public static IApplicationBuilder UseUsernamePassword_Validation(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UsernamePassword_Validation>();
        }
    }
}
