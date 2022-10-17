using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acc.Domain.Models;
using Acc.Infrastructure.EFCore.Mapping;
using Acc.Infrastructure.EFCore.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Acc.Infrastructure.EFCore.Context
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
