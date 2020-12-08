using Medusa.Business.Interface;
using Medusa.DataAccess.Interface;
using Medusa.Entities;

namespace Medusa.Business.Concrete
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
