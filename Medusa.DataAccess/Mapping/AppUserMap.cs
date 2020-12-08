using Medusa.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medusa.DataAccess.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUserEntity>
    {
        public void Configure(EntityTypeBuilder<AppUserEntity> builder)
        {
            builder.ToTable("tAppUser", "dbo");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Name).HasMaxLength(100);
            builder.Property(a => a.Surname).HasMaxLength(100);
            builder.Property(a => a.Email).HasMaxLength(100);
            builder.Property(a => a.UserName).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Password).IsRequired().HasMaxLength(100);

            builder.HasMany(a => a.Blogs).WithOne(a => a.AppUser).HasForeignKey(a => a.AppUserId);
        }
    }
}
