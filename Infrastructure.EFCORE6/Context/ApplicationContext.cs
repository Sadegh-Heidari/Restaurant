using Microsoft.EntityFrameworkCore;
using Resturan.Domain.Category;
using Resturan.Domain.FoodType;
using Resturan.Domain.MenuItem;
using Resturan.Infrastructure.EFCORE6.Mapping;

namespace Resturan.Infrastructure.EFCORE6.Context
{
    public class ApplicationContext:DbContext
    {
        public DbSet<CategoryModel>? Category { get; set; }
        public DbSet<FoodTypeModel>? FoodType { get; set; }
        public DbSet<MenuItemModel> MenuItem { get; set; }
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
