using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Movies.ItAcademy.Api.Models.DTO;
using MoviesManagement.Domain.Models;
using MoviesManagement.Services.Models;

namespace Movies.ItAcademy.Api.Infastructure.Mappings
{
    public static class RegisterMap
    {
        public static void AddMapping(this IServiceCollection serviceCollection)
        {
            TypeAdapterConfig<MovieDTO, MovieServiceModel>
                .NewConfig()
                .TwoWays();

            TypeAdapterConfig<Movie, MovieServiceModel>
               .NewConfig()
               .TwoWays();
        }
    }
}
