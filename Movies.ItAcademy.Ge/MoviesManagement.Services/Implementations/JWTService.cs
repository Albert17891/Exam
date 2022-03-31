using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MoviesManagement.Services.Abstractions;
using MoviesManagement.Services.Models.JWT;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MoviesManagement.Services.Implementations
{
    public class JWTService : IJWTService
    {
        private readonly string _secret;
        private readonly int _expirationMinutes;

        public JWTService(IOptions<JWTConfiguration> options)
        {
            _secret = options.Value.Secret;
            _expirationMinutes = options.Value.ExpirationMinutes;
        }
        public string GenerateToken(string username, string roleName)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username),


                      new Claim(ClaimTypes.Role, roleName)


                }),
                Expires = DateTime.UtcNow.AddMinutes(_expirationMinutes),
                Audience = "localhost",
                Issuer = "localhost",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}
