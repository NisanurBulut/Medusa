using Medusa.Business.Interface;
using Medusa.DataAccess.Interface;
using Medusa.Entities;

namespace Medusa.Business.Concrete
{
    public class BlogService : GenericService<BlogEntity>, MedusaService
    {
        private IGenericDal<BlogEntity> _genericDal;
        public BlogService(IGenericDal<BlogEntity> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }
    }
}
