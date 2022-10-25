﻿using Microsoft.EntityFrameworkCore;
using Resturan.Domain.Category;
using Resturan.Domain.FoodType;
using Resturan.Domain.MenuItem;
using Resturan.Domain.Order;
using Resturan.Domain.OrderDetail;
using Resturan.Domain.ShoppingCart;
using Resturan.Infrastructure.EFCORE6.Mapping;

namespace Resturan.Infrastructure.EFCORE6.Context
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
