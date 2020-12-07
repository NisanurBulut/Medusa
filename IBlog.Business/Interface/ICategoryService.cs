using IBlog.Entities;

namespace IBlog.Business.Interface
{
    // CategoryEntity tip için IGenericDal dan kalıtsal geç
    public interface ICategoryService : IGenericService<CategoryEntity>
    {
    }
}
