using IBlog.Business.Interface;
using IBlog.DataAccess.Interface;
using IBlog.Entities;

namespace IBlog.Business.Concrete
{
    public class BlogService : GenericService<BlogEntity>, IBlogService
    {
        private IGenericDal<BlogEntity> _genericDal;
        public BlogService(IGenericDal<BlogEntity> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }
    }
}
