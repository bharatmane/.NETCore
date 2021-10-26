using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace BM.DotNetCoreMiddlewareDemo.Middleware
{
    public class CustomLogicMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomLogicMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("My Custom Logic Middleware created in separate file.\n");
            await _next(httpContext); // calling next middleware
        }

    }
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CustomLogicMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomLogicMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomLogicMiddleware>();
        }

    }
}
