using Microsoft.EntityFrameworkCore;
using Restaurant.MainApp.Core.Domain.Category;
using Restaurant.MainApp.Core.Domain.FoodType;
using Restaurant.MainApp.Core.Domain.MenuItem;
using Restaurant.MainApp.Core.Domain.Order;
using Restaurant.MainApp.Core.Domain.OrderDetail;
using Restaurant.MainApp.Core.Domain.ShoppingCart;
using Restaurant.MainApp.Infrastructure.EFCORE6.Mapping;

namespace Restaurant.MainApp.Infrastructure.EFCORE6.Context
{
    public class ApplicationContext:DbContext
    {
        public DbSet<CategoryModel>? Category { get; set; }
        public DbSet<FoodTypeModel>? FoodType { get; set; }
        public DbSet<MenuItemModel> MenuItem { get; set; }
        public DbSet<ShoppingCartModel> ShoppingCart { get; set; }
        public DbSet<OrderDetailModel> OrderDetail { get; set; }
        public DbSet<OrderHeaderModel> OrderHeader { get; set; }
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
