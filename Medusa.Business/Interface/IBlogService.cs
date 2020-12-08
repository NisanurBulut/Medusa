using Medusa.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medusa.Business.Interface
{
    // BlogEntity tip için IGenericDal dan kalıtsal geç
    public interface IBlogService : IGenericService<BlogEntity>
    {
        Task<List<BlogEntity>> GetAllSortedByPostedTimeAsync();
    }
}
