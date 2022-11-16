using Microsoft.EntityFrameworkCore;
using Restaurant.UsersApp.Core.Domain.Models;
using Restaurant.UsersApp.Infrastructure.EFCore.Mapping;
using Restaurant.UsersApp.Infrastructure.EFCore.SeedData;

namespace Restaurant.UsersApp.Infrastructure.EFCore.Context
{
    public class AccContext:DbContext
    {
        public DbSet<Users> Userdb { get; set; }
        public DbSet<Role> Roledb { get; set; }
        public DbSet<UserRole> UserRoleDb { get; set; }
        public AccContext(DbContextOptions<AccContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(UserMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
    }
}
