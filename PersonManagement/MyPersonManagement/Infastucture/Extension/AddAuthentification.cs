using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace MyPersonManagement.Infastucture.Extension
{
    public static class AddAuthentification
    {
       
        public static IServiceCollection AddJwtAuth(this IServiceCollection services,IConfiguration options)
        {
            var key = Encoding.ASCII.GetBytes(options.GetSection("JwtConfiguration").GetSection("Secret").Value);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                
                    x.TokenValidationParameters=new TokenValidationParameters
                    {
                        IssuerSigningKey=new SymmetricSecurityKey(key),
                        ValidateIssuer=true,
                        ValidateAudience=true,
                        ValidIssuer="localhost",
                        ValidAudience="localhost"
                    }
                );

            return services;
        }
    }
}
