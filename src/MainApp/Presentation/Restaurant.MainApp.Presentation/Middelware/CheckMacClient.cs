using System.Net.NetworkInformation;
using System.Security.Claims;

namespace Restaurant.MainApp.Presentation.Middelware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CheckMacClient
    {
        private readonly RequestDelegate _next;

        public CheckMacClient(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var clientMac = GetMac();
            var ClaimIp = httpContext.User.FindFirstValue(ClaimTypes.System);
            if (ClaimIp != null && ClaimIp != clientMac)
            {
                //await httpContext.SignOutAsync();
                httpContext.Request.Path = "/Errors/AccessDenied/Access";
                 await _next(httpContext);
                 return;
            }

            await _next(httpContext);
        }

        private string GetMac()
        {
            var result = "";
            foreach (NetworkInterface n in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (n.OperationalStatus == OperationalStatus.Up)
                {
                    result += n.GetPhysicalAddress().ToString();
                    break;
                }
            }

            return result;
        }
    }
    
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CheckIpClientExtensions
    {
        public static IApplicationBuilder UseCheckIpClient(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CheckMacClient>();
        }
    }
}
