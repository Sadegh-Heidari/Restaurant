using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acc.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Acc.Infrastructure.EFCore.Mapping
{
    public class RoleMapping:IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.RoleName).HasMaxLength(200).IsRequired();
            builder.HasMany(x => x.UserRoles).WithOne(x => x.RoleModel).HasForeignKey(x => x.RoleId);
        }
    }
}
