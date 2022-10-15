using Acc.Application;
using Acc.Domain.Services;
using Acc.Infrastructure.EFCore.Context;
using Acc.Infrastructure.EFCore.Repository;
using Acc.Services.HashPassword;
using Acc.Services.Services;
using Autnen;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Acc.Bootstraper
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