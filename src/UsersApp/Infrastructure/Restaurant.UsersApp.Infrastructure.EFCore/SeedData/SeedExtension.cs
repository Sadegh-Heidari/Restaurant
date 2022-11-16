using Microsoft.EntityFrameworkCore;
using Restaurant.UsersApp.Core.Application;
using Restaurant.UsersApp.Core.Application.Services.HashPassword;
using Restaurant.UsersApp.Core.Domain.Models;
namespace Restaurant.UsersApp.Infrastructure.EFCore.SeedData
{
    public static class SeedExtension
    {
        private static IHashPassword _hash { get; set; }

        static SeedExtension()
        {
            _hash = new HashPassword();
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            var Password = _hash.Hash("126543210mM$");
            modelBuilder.Entity<Users>().HasData(new Users("Manager", "Admin@gmail.com", "111111", Password));
            modelBuilder.Entity<Users>().HasData(new Users("Kitchen", "Kitchen@gmail.com", "111111", Password));
            modelBuilder.Entity<Users>().HasData(new Users("FrontDesk", "FrontDesk@gmail.com", "111111", Password));
            modelBuilder.Entity<Role>().HasData(new Role("Admin"));
            modelBuilder.Entity<Role>().HasData(new Role("Kitchen"));
            modelBuilder.Entity<Role>().HasData(new Role("FrontDesk"));
           
        }
    }
}
