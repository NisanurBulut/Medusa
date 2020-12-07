using IBlog.DataAccess.Interface;
using IBlog.Entities;

namespace IBlog.DataAccess.Concrete
{
    public class CategoryRepository : GenericDal<CategoryEntity>, ICategoryDal
    {
    }
}
