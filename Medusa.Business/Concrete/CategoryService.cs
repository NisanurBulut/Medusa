using Medusa.Business.Interface;
using Medusa.DataAccess.Interface;
using Medusa.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medusa.Business.Concrete
{
    public class CategoryService : GenericService<CategoryEntity>, ICategoryService
    {
        private IGenericDal<CategoryEntity> _genericDal;
        public CategoryService(IGenericDal<CategoryEntity> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task<List<CategoryEntity>> GetAllSortedById()
        {
            return await _genericDal.GetAllAsync(a => a.Id);
        }
    }
}
