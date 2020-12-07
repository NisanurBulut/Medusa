using IBlog.DataAccess.Interface;
using IBlog.Entities;

namespace IBlog.DataAccess.Concrete
{
    public class BlogRepository : GenericDal<BlogEntity>, IBlogDal
    {
    }
}
