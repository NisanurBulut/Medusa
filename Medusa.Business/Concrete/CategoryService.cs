using Medusa.Business.Interface;
using Medusa.DataAccess.Interface;
using Medusa.Entities;

namespace Medusa.Business.Concrete
{
    public class CategoryService : GenericService<CategoryEntity>, ICategoryService
    {
        private IGenericDal<CategoryEntity> _genericDal;
        public CategoryService(IGenericDal<CategoryEntity> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }
    }
}
