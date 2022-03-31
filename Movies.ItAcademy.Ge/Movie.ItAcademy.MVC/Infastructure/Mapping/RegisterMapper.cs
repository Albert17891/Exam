using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Movies.ItAcademy.MVC.Models.DTO;
using MoviesManagement.Domain.Models;
using MoviesManagement.Services.Models;

namespace Movies.ItAcademy.MVC.Infastructure.Mapping
{
    public static class RegisterMapper
    {
        public static void AddMapper(this IServiceCollection serviceCollection)
        {
            TypeAdapterConfig<MovieServiceModel, MovieDTO>
                .NewConfig()
                .Map(dest => dest.Image, src => src.ImageUrl);

            TypeAdapterConfig<Movie, MovieServiceModel>
               .NewConfig()
               .TwoWays();

        }
    }
}
