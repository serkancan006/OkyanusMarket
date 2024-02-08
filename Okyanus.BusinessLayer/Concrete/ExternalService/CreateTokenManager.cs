using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Okyanus.BusinessLayer.Abstract.ExternalService;
using Okyanus.EntityLayer.Entities.identitiy;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.BusinessLayer.Concrete.ExternalService
{
    public class CreateTokenManager : ICreateTokenService
    {
        private readonly IConfiguration _configuration;
        public CreateTokenManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenDto TokenCreate(AppUser user, int second = 60)
        {
            var bytes = Encoding.UTF8.GetBytes(_configuration["JwtTokenOptions:IssuerSigningKey"]);
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>()
            {
                //new Claim(ClaimTypes.NameIdentifier,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.GivenName, user.Name),
                new Claim(ClaimTypes.Surname, user.Surname),
            };
            DateTime expires = DateTime.Now.AddSeconds(second);
            JwtSecurityToken token = new JwtSecurityToken(issuer: _configuration["JwtTokenOptions:ValidIssuer"], audience: _configuration["JwtTokenOptions:ValidAudience"], notBefore: DateTime.Now, expires: expires, signingCredentials: credentials, claims: claims);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            TokenDto Token = new()
            {
                Token = handler.WriteToken(token),
                Expires = expires
            };

            return Token;
        }

        public TokenDto TokenCreateAdmin(AppUser user, int second = 60)
        {
            var bytes = Encoding.UTF8.GetBytes(_configuration["JwtTokenOptions:IssuerSigningKey"]);
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>()
            {
                //new Claim(ClaimTypes.NameIdentifier,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.GivenName, user.Name),
                new Claim(ClaimTypes.Surname, user.Surname),
                new Claim(ClaimTypes.Role, "Admin")
                //new Claim(ClaimTypes.Role,"Instructor"),
            };

            DateTime expires = DateTime.Now.AddSeconds(second);
            JwtSecurityToken token = new JwtSecurityToken(issuer: _configuration["JwtTokenOptions:ValidIssuer"], audience: _configuration["JwtTokenOptions:ValidAudience"], notBefore: DateTime.Now, expires: expires, signingCredentials: credentials, claims: claims);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            TokenDto Token = new()
            {
                Token = handler.WriteToken(token),
                Expires = expires
            };
            return Token;
        }

    }

    public class TokenDto
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
