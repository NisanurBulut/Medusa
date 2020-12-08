using Medusa.DataAccess.Interface;
using Medusa.Entities;

namespace Medusa.DataAccess.Concrete
{
    public class AppUserRepository : GenericDal<AppUserEntity>, IAppUserDal
    {
    }
}
