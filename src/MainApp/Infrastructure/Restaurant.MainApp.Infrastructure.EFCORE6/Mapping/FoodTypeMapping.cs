using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.MainApp.Core.Domain.FoodType;

namespace Restaurant.MainApp.Infrastructure.EFCORE6.Mapping
{
    public class FoodTypeMapping:IEntityTypeConfiguration<FoodTypeModel>
    {
        public void Configure(EntityTypeBuilder<FoodTypeModel> builder)
        {
            builder.ToTable("FoodType");
            builder.HasKey(x => x.Guid);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
        }
    }
}
