using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PersonService.Abstractions;
using PersonService.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;

namespace PersonService.Implementations
{
    public class JwtService : IJwtService
    {
        private readonly string _secret;
        private readonly int _expirationTime;

        public JwtService(IOptions<JwtConfiguration> options)
        {
            _secret = options.Value.Secret;
            _expirationTime = options.Value.ExpirationTime;
        }

      
        public string GenerateSecurityJwt(string name)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, name),
                }),

                Expires = DateTime.UtcNow.AddMinutes(_expirationTime),
                Audience = "localhost",
                Issuer="localhost",
                SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
