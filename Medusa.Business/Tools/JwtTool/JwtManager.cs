using Medusa.Business.StringInfo;
using Medusa.Entities;
using Microsoft.Extensions.Options;
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
        private readonly IOptions<JwtInfo> _jwtInfoOptions;
        public JwtManager(IOptions<JwtInfo> jwtInfoOptions)
        {
            _jwtInfoOptions = jwtInfoOptions;
        }
        public JwtToken GenerateJwt(AppUserEntity appUser)
        {
            var jwtInfo = _jwtInfoOptions.Value;
            JwtToken jwtToken = new JwtToken();

            SymmetricSecurityKey symmetricSecurity = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtInfo.SECURITYKEY));

            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurity, SecurityAlgorithms.HmacSha512);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(jwtInfo.ISSUER,
                jwtInfo.AUDIENCE, SetClaims(appUser), DateTime.Now, DateTime.Now.AddMinutes(jwtInfo.EXPIRES), signingCredentials);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();


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
