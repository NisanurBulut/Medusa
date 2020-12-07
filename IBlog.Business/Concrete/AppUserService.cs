using IBlog.Business.Interface;
using IBlog.DataAccess.Interface;
using IBlog.Entities;

namespace IBlog.Business.Concrete
{
    public class AppUserService : GenericService<AppUserEntity>, IAppUserService
    {
        private IGenericDal<AppUserEntity> _genericDal;
        public AppUserService(IGenericDal<AppUserEntity> genericDal) :base(genericDal)
        {
            _genericDal = genericDal;
        }
    }
}
