using Medusa.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Medusa.Business.Tools
{
    public interface IJwtService
    {
        JwtToken GenerateJwt(AppUserEntity appUser);
    }
}
