using IBlog.DataAccess.Interface;
using IBlog.Entities;

namespace IBlog.DataAccess.Concrete
{
    public class AppUserRepository : GenericDal<AppUserEntity>, IAppUserDal
    {
    }
}
