using Microsoft.EntityFrameworkCore;
using IBlog.Entities;
using IBlog.DataAccess.Mapping;

namespace IBlog.DataAccess.Context
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=../IBlog.DataAccess/Context/IBlog.db");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new BlogMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
            modelBuilder.ApplyConfiguration(new CategoryBlogMap());

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<AppUserEntity> tAppUser { get; set; }
        public DbSet<CommentEntity> tComment { get; set; }
        public DbSet<BlogEntity> tBlog { get; set; }
        public DbSet<CategoryEntity> tCategory { get; set; }
        public DbSet<CategoryBlogEntity> tCategoryBlog { get; set; }

    }
}
