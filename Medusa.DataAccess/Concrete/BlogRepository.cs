using Medusa.DataAccess.Context;
using Medusa.DataAccess.Interface;
using Medusa.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medusa.DataAccess.Concrete
{
    public class BlogRepository : GenericDal<BlogEntity>, IBlogDal
    {
        public async Task<List<BlogEntity>> GetAllByCategoryIdAsync(int id)
        {
            using var context = new DatabaseContext();
            return await context.tBlog.Join(context.tCategoryBlog, b => b.Id, cb => cb.BlogId,
                (blog, categoryBlog) => new
                {
                    blog = blog,
                    categoryBlog = categoryBlog
                }).Where(a => a.categoryBlog.CategoryId == id).Select(a => new BlogEntity
                {
                    AppUser = a.blog.AppUser,
                    AppUserId = a.blog.AppUserId,
                    CategoryBlogs = a.blog.CategoryBlogs,
                    Comments = a.blog.Comments,
                    LongDescription = a.blog.LongDescription,
                    ShortDescription = a.blog.ShortDescription,
                    Id = a.blog.Id,
                    ImagePath = a.blog.ImagePath,
                    PostedTime = a.blog.PostedTime,
                    Title = a.blog.Title
                }).ToListAsync();
        }
    }
}
