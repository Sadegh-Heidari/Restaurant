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
    public class UserRoleMapping:IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRole");
            builder.HasKey(x => new { x.RoleId, x.UserId });
            builder.HasOne<Users>(x => x.UserModel).WithMany(x => x.UserRoles).HasForeignKey(x => x.UserId);
            builder.HasOne<Role>(x => x.RoleModel).WithMany(x => x.UserRoles).HasForeignKey(x => x.RoleId);
        }
    }
}
