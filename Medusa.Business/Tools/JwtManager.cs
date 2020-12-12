using Medusa.Business.StringInfo;
using Medusa.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Medusa.Business.Tools
{
    class JwtManager : IJwtService
    {
        public JwtToken GenerateJwt(AppUserEntity appUser)
        {
            SymmetricSecurityKey symmetricSecurity = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfo.SECURITYKEY));
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurity, SecurityAlgorithms.HmacSha512);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(JwtInfo.ISSUER,
                JwtInfo.AUDIENCE, SetClaims(appUser), DateTime.Now, DateTime.Now.AddMinutes(JwtInfo.EXPIRES), signingCredentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtToken jwtToken = new JwtToken();
            jwtToken.Token = handler.WriteToken(jwtSecurityToken);
            return jwtToken;
        }
        private List<Claim> SetClaims(AppUserEntity appUser)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, appUser.Name));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, appUser.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Email, appUser.Email));

            return claims;
        }
    }
}
