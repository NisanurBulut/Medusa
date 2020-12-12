using Medusa.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medusa.DataAccess.Interface
{
    public interface ICategoryDal:IGenericDal<CategoryEntity>
    {
        Task<List<CategoryEntity>> GetAllWithCategoryBlogAsync();
    }
}
