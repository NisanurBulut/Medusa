using Medusa.Entities;

namespace Medusa.Business.Interface
{
    // CategoryEntity tip için IGenericDal dan kalıtsal geç
    public interface ICategoryService : IGenericService<CategoryEntity>
    {
    }
}
