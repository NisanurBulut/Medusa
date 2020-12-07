using IBlog.Entities;

namespace IBlog.Business.Interface
{
    // BlogEntity tip için IGenericDal dan kalıtsal geç
    public interface IBlogService : IGenericService<BlogEntity>
    {
    }
}
