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
        private readonly DatabaseContext _context;
        public CategoryRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<CategoryEntity>> GetAllWithCategoryBlogAsync()
        {
            
            return await _context.tCategory.Include(a => a.CategoryBlogs)
                .OrderByDescending(a => a.Id)
                .ToListAsync();
        }
    }
}
