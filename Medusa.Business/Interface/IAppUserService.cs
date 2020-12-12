using Medusa.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Medusa.DataTransferObject;

namespace Medusa.Business.Interface
{
   public interface IAppUserService:IGenericService<AppUserEntity>
    {
        Task<AppUserEntity> CheckUserAsync(AppUserLoginDto appUserLoginDto);
    }
}
