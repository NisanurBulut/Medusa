using Medusa.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Medusa.DataAccess.Mapping
{
    public class BlogMap : IEntityTypeConfiguration<BlogEntity>
    {
        public void Configure(EntityTypeBuilder<BlogEntity> builder)
        {
            builder.ToTable("tBlog", "dbo");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Title).IsRequired().HasMaxLength(100);
            builder.Property(a => a.ShortDescription).HasColumnType("ntext").HasMaxLength(300);
            builder.Property(a => a.LongDescription).HasColumnType("ntext");
            builder.Property(a => a.ImagePath).HasMaxLength(300);
            builder.HasMany(a => a.Comments).WithOne(a => a.Blog).HasForeignKey(a => a.BlogId);
            builder.HasMany(a => a.CategoryBlogs).WithOne(a => a.Blog).HasForeignKey(a => a.BlogId);
        }
    }
}
