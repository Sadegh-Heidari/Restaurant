using AC.Infrastructure.EFCORE;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace bootstraper
{
    public static class AddAccountService
    {
        public static void AddAccountServices(this IServiceCollection service, string coonection)
        {
            service.AddDbContext<AccountContext>(x => x.UseSqlServer(coonection));
        }
    }
}