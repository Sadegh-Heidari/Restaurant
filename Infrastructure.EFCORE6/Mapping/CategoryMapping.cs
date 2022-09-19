using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resturan.Domain.Category;

namespace Infrastructure.EFCORE6.Mapping
{
    public class CategoryMapping:IEntityTypeConfiguration<CategoryModel>
    {
        public void Configure(EntityTypeBuilder<CategoryModel> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(x => x.Guid);
            builder.Property(x=>x.Name).IsRequired().HasMaxLength(250);
            builder.Property(x => x.DisplayOrder).IsRequired();
        }
    }
}
