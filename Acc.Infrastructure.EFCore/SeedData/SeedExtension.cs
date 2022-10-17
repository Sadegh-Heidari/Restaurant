using Acc.Application;
using Acc.Domain.Models;
using Acc.Services.HashPassword;
using Microsoft.EntityFrameworkCore;

namespace Acc.Infrastructure.EFCore.SeedData
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
            modelBuilder.Entity<UserRole>().HasData(new UserRole("3062d373-692a-4719-af17-e539348cedf5", "c2fba437-1de8-440b-902d-8dda014454e0"));
            modelBuilder.Entity<UserRole>().HasData(new UserRole("383cac8c-52db-4910-9d82-436ec592b223", "c2fba437-1de8-440b-902d-8dda014454e0"));
            modelBuilder.Entity<UserRole>().HasData(new UserRole("7d873ea9-74df-417a-b56a-660d16d87a27", "c2fba437-1de8-440b-902d-8dda014454e0"));


            modelBuilder.Entity<UserRole>().HasData(new UserRole("3062d373-692a-4719-af17-e539348cedf5", "130447bc-a90b-418d-8e2c-fbc5a710dd80"));
            modelBuilder.Entity<UserRole>().HasData(new UserRole("7d873ea9-74df-417a-b56a-660d16d87a27", "ec5575d0-b739-46f1-b91b-d30e26db1491"));
        }
    }
}
