using IBlog.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IBlog.DataAccess.Mapping
{
    public class CategoryBlogMap : IEntityTypeConfiguration<CategoryBlogEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryBlogEntity> builder)
        {
            builder.ToTable("tCategoryBlog", "dbo");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.HasIndex(a => new { a.CategoryId, a.BlogId }).IsUnique();
        }
    }
}
