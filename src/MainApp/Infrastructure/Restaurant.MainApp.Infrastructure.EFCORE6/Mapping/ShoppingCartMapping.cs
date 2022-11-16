using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.MainApp.Core.Domain.ShoppingCart;

namespace Restaurant.MainApp.Infrastructure.EFCORE6.Mapping
{
    public class ShoppingCartMapping:IEntityTypeConfiguration<ShoppingCartModel>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartModel> builder)
        {
            builder.ToTable("ShoppingCart");
            builder.HasKey(x => x.Guid);
            builder.Property(x => x.Email).HasMaxLength(200).IsRequired();
            builder.Property(x => x.UserName).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Count).IsRequired();
            builder.HasOne(x => x.MenuItem).WithMany(x => x.ShoppingCart).HasForeignKey(x => x.MenuItemId);
        }
    }
}
