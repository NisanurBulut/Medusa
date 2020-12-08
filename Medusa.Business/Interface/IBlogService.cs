using Medusa.Entities;

namespace Medusa.Business.Interface
{
    // BlogEntity tip için IGenericDal dan kalıtsal geç
    public interface MedusaService : IGenericService<BlogEntity>
    {
    }
}
