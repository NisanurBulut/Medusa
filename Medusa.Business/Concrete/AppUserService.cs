using Medusa.Business.Interface;
using Medusa.DataAccess.Interface;
using Medusa.DataTransferObject;
using Medusa.Entities;
using System.Threading.Tasks;

namespace Medusa.Business.Concrete
{
    public class AppUserService : GenericService<AppUserEntity>, IAppUserService
    {
        private IGenericDal<AppUserEntity> _genericDal;
        public AppUserService(IGenericDal<AppUserEntity> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task<AppUserEntity> CheckUserAsync(AppUserLoginDto appUserLoginDto)
        {
            return await _genericDal.GetAsync(a => a.UserName == appUserLoginDto.UserName && a.Password == appUserLoginDto.Password);
        }
    }
}
