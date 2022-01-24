using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using SuperTraders.Core.Entities;
using SuperTraders.Infrastructure;
using SuperTraders.Services.Infrastructure;

namespace SuperTraders.Presentation.Middlewares
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var headers = context.Request.Headers;
            StringValues token = "";
            if (headers.TryGetValue("Authorization", out token))
            {
                using (TokenGenerator tokenGenerator = new TokenGenerator())
                {
                    try
                    {
                        tokenGenerator.SplitToken(token.ToString());
                    }
                    catch
                    {
                        context.Response.StatusCode = 401;
                        await context.Response.WriteAsync("Not Authenticated!");
                    }
                    
                    var uService = context.RequestServices.GetService(typeof(IUserService));
                    if (uService is IUserService userService)
                    {
                        User? user = await userService.GetUserByToken(token.ToString());
                        if (user == null)
                        {
                            context.Response.StatusCode = 401;
                            await context.Response.WriteAsync("Not Authenticated!");
                        }
                        else
                        {
                            context.Items.Add("user", user);
                            await _next(context);
                        }
                    }
                }
            }
            else
            {
                await _next(context);
            }
        }
    }
}