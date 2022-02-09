using CarRepository;
using CarRepository.Data;
using CarRepository.Data.DataContext;
using Microsoft.Extensions.DependencyInjection;

namespace CarApi.Infastructure.Extension
{
    public static class RepoService
    {
        public static void AddRepo(this IServiceCollection service)
        {
            service.AddScoped<IRepositoryService, RepositoryService>();
            service.AddScoped<ICarSpecRepository, RepositorySpecService>();
        }
    }
}
