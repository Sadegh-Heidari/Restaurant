using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.MainApp.Core.Application;
using Restaurant.MainApp.Core.Application.Contract.ApplicationServices;
using Restaurant.MainApp.Core.Application.Query;
using Restaurant.MainApp.Core.Domain.Services;
using Restaurant.MainApp.Infrastructure.EFCORE6.Context;
using Restaurant.MainApp.Infrastructure.EFCORE6.Repositories;

namespace Resturan.Infrastructure.Service
{
    public static class PresentationLayyerServices
    {
        public static void AddService(this IServiceCollection service,string connection)
        {
            
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped<IRepositoryCategory, RepositoryCategory>();
            service.AddScoped<IRepositoryFoodType, RepositoryFoodType>();
            service.AddScoped<IApplicationCategory, ApplicationCategory>();
            service.AddScoped<IApplicationFoodType, ApplicationFoodType>();
            service.AddScoped<IRepositoryMenuItem, RepositoryMenuItem>();
            service.AddScoped<IApplicationMenuItem, ApplicationMenuItem>();
            service.AddScoped<IApplicationQuery, ApplicationQuery>();
            service.AddScoped<IApplicationShoppingCart, ApplicationShoppingCart>();
            service.AddScoped<IApplicationOrder, ApplicationOrder>();
            service.AddScoped<IApplicationStatus, ApplicationStatus>();
            service.AddDbContext<ApplicationContext>(x =>
                x.UseSqlServer(connection));
        }

        public static void CreatDataBase(this IServiceProvider service)
        {
            var type = service.GetService<IServiceScopeFactory>();
            type?.CreateScope()?.ServiceProvider.GetService<ApplicationContext>()?.Database.Migrate();
        }
    }
}
