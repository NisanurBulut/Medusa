using Medusa.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medusa.Business.Interface
{
    // CategoryEntity tip için IGenericDal dan kalıtsal geç
    public interface ICategoryService : IGenericService<CategoryEntity>
    {
        Task<List<CategoryEntity>> GetAllSortedByIdTime();
    }
}
