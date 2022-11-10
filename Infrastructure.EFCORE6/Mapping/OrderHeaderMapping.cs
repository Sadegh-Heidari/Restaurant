using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resturan.Domain.Order;

namespace Resturan.Infrastructure.EFCORE6.Mapping
{
    public class OrderHeaderMapping:IEntityTypeConfiguration<OrderHeaderModel>
    {
        public void Configure(EntityTypeBuilder<OrderHeaderModel> builder)
        {
            builder.ToTable("OrderHeader");
            builder.HasKey(x => x.OrderNumber);
            builder.Property(x => x.Comments).HasMaxLength(350);
            builder.Property(x => x.PhoneNumber).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(200).IsRequired();
            builder.Property(x => x.PickupName).HasMaxLength(200).IsRequired();
            builder.Property(x => x.SessionId).HasMaxLength(200);
            builder.Property(x => x.PaymentIntentId).HasMaxLength(200);
            builder.Property(x => x.Status).HasMaxLength(200).IsRequired();
            builder.Property(x => x.PickupDate).IsRequired();
            builder.Property(x => x.PickupTime).IsRequired();
            builder.Property(x => x.OrderDate).IsRequired();
            builder.Property(x => x.OrderTotal).IsRequired();
        }
    }
}
