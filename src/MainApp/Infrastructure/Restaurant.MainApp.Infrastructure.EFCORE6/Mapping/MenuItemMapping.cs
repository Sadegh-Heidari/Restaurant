using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.MainApp.Core.Domain.MenuItem;

namespace Restaurant.MainApp.Infrastructure.EFCORE6.Mapping
{
    public class MenuItemMapping:IEntityTypeConfiguration<MenuItemModel>
    {
        public void Configure(EntityTypeBuilder<MenuItemModel> builder)
        {
            builder.ToTable("MenuItem");
            builder.HasKey(x => x.Guid);
            builder.HasOne(x => x.FoodType).WithMany(x => x.MenuItems).HasForeignKey(x => x.FoodTypeId);
            builder.HasOne(x => x.Category).WithMany(x => x.MenuItems).HasForeignKey(x => x.CategoryId);
        }
    }
}
