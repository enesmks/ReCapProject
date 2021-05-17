using Microsoft.AspNetCore.Builder;

namespace Core.Extensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureCustomeExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
