using Medusa.DataAccess.Context;
using Medusa.DataAccess.Interface;
using Medusa.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medusa.DataAccess.Concrete
{
    public class CategoryRepository : GenericDal<CategoryEntity>, ICategoryDal
    {
        public async Task<List<CategoryEntity>> GetAllWithCategoryBlogAsync()
        {
            using var context = new DatabaseContext();
            return await context.tCategory.Include(a => a.CategoryBlogs)
                .OrderByDescending(a => a.Id)
                .ToListAsync();
        }
    }
}
