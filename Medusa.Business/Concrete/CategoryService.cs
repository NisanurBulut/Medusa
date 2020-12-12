using Medusa.Business.Interface;
using Medusa.DataAccess.Interface;
using Medusa.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medusa.Business.Concrete
{
    public class CategoryService : GenericService<CategoryEntity>, ICategoryService
    {
        private readonly IGenericDal<CategoryEntity> _genericDal;
        private readonly ICategoryDal _categoryDal;
        public CategoryService(IGenericDal<CategoryEntity> genericDal, ICategoryDal categoryDal) : base(genericDal)
        {
            _categoryDal = categoryDal;
            _genericDal = genericDal;
        }

        public async Task<List<CategoryEntity>> GetAllSortedById()
        {
            return await _genericDal.GetAllAsync(a => a.Id);
        }

        public async Task<List<CategoryEntity>> GetAllWithCategoryBlogAsync()
        {
            return await _categoryDal.GetAllWithCategoryBlogAsync();
        }
    }
}
