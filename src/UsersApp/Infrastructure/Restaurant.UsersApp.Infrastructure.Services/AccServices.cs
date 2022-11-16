using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.UsersApp.Core.Application;
using Restaurant.UsersApp.Core.Application.Services.HashPassword;
using Restaurant.UsersApp.Core.Application.Services.Services;
using Restaurant.UsersApp.Core.Domain.Services;
using Restaurant.UsersApp.Infrastructure.Autnen;
using Restaurant.UsersApp.Infrastructure.EFCore.Context;
using Restaurant.UsersApp.Infrastructure.EFCore.Repository;

namespace Restaurant.UsersApp.Infrastructure.Services
{
    public static class AccServices
    {
        public static void AccService(this IServiceCollection service, string connection,string LoginPath,string AccessDenied)
        {
            service.AddHttpContextAccessor();
            service.AddScoped<IUserApplication, UserApplication>();
            service.AddScoped<IRoleApplication, RoleApplication>();
            service.AddScoped<IHashPassword, HashPassword>();
            service.AddScoped<IAccUnitOfWork, AccUnitOfWork>();
            service.AddScoped<IOperationValue, OperationValue>();
            service.AddScoped<ISignUser, SignUser>();
            service.AddDbContext<AccContext>(x => x.UseSqlServer(connection));
            service.AddAuthentication(Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults
                .AuthenticationScheme).AddCookie(Microsoft.AspNetCore.Authentication.Cookies
                .CookieAuthenticationDefaults.AuthenticationScheme, op =>
            {
                op.LoginPath = LoginPath;
                op.AccessDeniedPath = AccessDenied;
            });
        }


    }
}