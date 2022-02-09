using CarApi.Infastructure.Extension;
using CarService.Abstractions;
using CarService.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace CarApi.Infastructure.Services
{
    public static class AddService
    {
        public static void AddServices(this IServiceCollection service)
        {
            service.AddScoped<ICarService, CarServices>();
            service.AddScoped<ICarSpecService, CarSpecService>();

            service.AddRepo();
        }
    }
}
