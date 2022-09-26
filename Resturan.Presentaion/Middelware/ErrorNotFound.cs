using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Resturan.Presentation.Middelware
{
	// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
	public class ErrorNotFound
	{
		private readonly RequestDelegate _next;

		public ErrorNotFound(RequestDelegate next)
		{
			_next = next;
		}

		public Task Invoke(HttpContext httpContext)
		{

			return _next(httpContext);
		}
	}

	// Extension method used to add the middleware to the HTTP request pipeline.
	public static class ErrorNotFoundExtensions
	{
		public static IApplicationBuilder UseErrorNotFound(this IApplicationBuilder builder)
		{
            builder.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404)
                {
                    context.Request.Path = "/Admin/Errors/404/NotFound";
                    await next();
                }
            });
            return builder.UseMiddleware<ErrorNotFound>();
		}
	}
}
