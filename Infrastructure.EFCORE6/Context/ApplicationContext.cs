using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.EFCORE6.Mapping;
using Microsoft.EntityFrameworkCore;
using Resturan.Domain.Category;
using Resturan.Domain.FoodType;

namespace Infrastructure.EFCORE6.Context
{
    public class ApplicationContext:DbContext
    {
        public DbSet<CategoryModel> Category { get; set; }
        public DbSet<FoodTypeModel> FoodType { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(CategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
