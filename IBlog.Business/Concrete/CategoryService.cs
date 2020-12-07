using IBlog.Business.Interface;
using IBlog.DataAccess.Interface;
using IBlog.Entities;

namespace IBlog.Business.Concrete
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
