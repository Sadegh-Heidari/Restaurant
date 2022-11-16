using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.UsersApp.Core.Domain.Models;

namespace Restaurant.UsersApp.Infrastructure.EFCore.Mapping
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
