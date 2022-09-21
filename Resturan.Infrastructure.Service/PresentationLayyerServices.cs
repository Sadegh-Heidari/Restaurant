using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Resturan.Application;
using Resturan.Application.Service.ApplicationServices;
using Resturan.Application.Service.DTO;
using Resturan.Application.Service.DTO.Category;
using Resturan.Domain.Services;
using Resturan.Infrastructure.EFCORE6.Context;
using Resturan.Infrastructure.EFCORE6.Repositories;

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
            service.AddTransient<CreatCategoryDTO>();
            service.AddTransient<UpdateCategoryDTO>();
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
