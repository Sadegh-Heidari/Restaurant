namespace Restaurant.MainApp.Presentation.Middelware
{
	// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
	public class ErrorNotFound
	{
		private readonly RequestDelegate _next;

		public ErrorNotFound(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext httpContext)
		{
            await _next(httpContext);
            if (httpContext.Response.StatusCode == 404)
            {
                httpContext.Request.Path = "/Errors/404/NotFound";
                await _next(httpContext);
            }
          
		}
	}

	// Extension method used to add the middleware to the HTTP request pipeline.
	public static class ErrorNotFoundExtensions
	{
		public static IApplicationBuilder UseErrorNotFound(this IApplicationBuilder builder)
		{
            return builder.UseMiddleware<ErrorNotFound>();
		}
	}
}
