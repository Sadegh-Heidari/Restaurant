using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.UsersApp.Core.Domain.Models;

namespace Restaurant.UsersApp.Infrastructure.EFCore.Mapping
{
    public class UserMapping:IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName).HasMaxLength(200).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(300).IsRequired();
            builder.Property(x => x.PhoneConfirmed).IsRequired();
            builder.HasMany(x=>x.UserRoles).WithOne(x=>x.UserModel).HasForeignKey(x=>x.UserId);
        }
    }
}
