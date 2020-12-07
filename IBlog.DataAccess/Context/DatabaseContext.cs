using Microsoft.EntityFrameworkCore;
using IBlog.Entities;

namespace IBlog.DataAccess.Context
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=~/IBlog.DataAccess/Context/IBlog.db");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<AppUserEntity> tAppUser { get; set; }
        public DbSet<CommentEntity> tComment { get; set; }
        public DbSet<BlogEntity> tBlog { get; set; }
        public DbSet<CategoryEntity> tCategory { get; set; }
        public DbSet<CategoryBlogEntity> tCategoryBlog { get; set; }

    }
}
