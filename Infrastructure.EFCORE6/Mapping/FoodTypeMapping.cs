using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resturan.Domain.FoodType;

namespace Infrastructure.EFCORE6.Mapping
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
