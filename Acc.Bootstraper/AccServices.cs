using Acc.Infrastructure.EFCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Acc.Bootstraper
{
    public static class AccServices
    {
        public static void AccService(this IServiceCollection service, string connection)
        {
            service.AddDbContext<AccContext>(x => x.UseSqlServer(connection));
        }
    }
}