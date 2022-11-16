using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.MainApp.Core.Domain.OrderDetail;

namespace Restaurant.MainApp.Infrastructure.EFCORE6.Mapping
{
    public class OrderDetailMapping:IEntityTypeConfiguration<OrderDetailModel>
    {
        public void Configure(EntityTypeBuilder<OrderDetailModel> builder)
        {
            builder.ToTable("OrderDetail");
            builder.HasKey(x => x.Guid);
            builder.Property(x => x.Count).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Price).HasMaxLength(200).IsRequired();
            builder.HasOne(x => x.MenuItem).WithMany(x => x.OrderDetailModels).HasForeignKey(x => x.MenuItemId);
            builder.HasOne(x => x.OrderHeader).WithMany(x => x.OrderDetail).HasForeignKey(x => x.OrderID);
        }
    }
}
