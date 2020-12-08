using Medusa.Business.Interface;
using Medusa.DataAccess.Interface;
using Medusa.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medusa.Business.Concrete
{
    public class BlogService : GenericService<BlogEntity>, IBlogService
    {
        private IGenericDal<BlogEntity> _genericDal;
        public BlogService(IGenericDal<BlogEntity> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task<List<BlogEntity>> GetAllSortedByPostedTimeAsync()
        {
            return await _genericDal.GetAllAsync(I => I.PostedTime);
        }
    }
}
