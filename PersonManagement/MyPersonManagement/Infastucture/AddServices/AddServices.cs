using Microsoft.Extensions.DependencyInjection;
using MyPersonManagement.Infastucture.AddRepositories;
using MyPersonManagement.Infastucture.Mapping;
using PersonService.Abstractions;
using PersonService.Implementations;
using System;

namespace MyPersonManagement.Infastucture.AddServices
{
    public static class AddServices
    {
        public static void AddService(this IServiceCollection service)
        {
            service.AddScoped<IPersonService, PersonServices>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IJwtService, JwtService>();

            service.AddRepo();
        }

      
    }
}
