using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Movies.ManagementPanel.Models.Movie.DTO;
using Movies.ManagementPanel.Models.Movie.Request;
using MoviesManagement.Domain.Models;
using MoviesManagement.Services.Models;

namespace Movies.ManagementPanel.Infastructure.Mapping
{
    public static class RegisterMapper
    {
        public static void AddMapper(this IServiceCollection serviceCollection)
        {
            TypeAdapterConfig<MovieServiceModel, MovieDTO>
                .NewConfig()
                .Map(dest => dest.Image, src => src.ImageUrl);

            TypeAdapterConfig<MovieDTO, MovieServiceModel>
                .NewConfig()
                .Map(dest => dest.ImageUrl, src => src.Image);

            TypeAdapterConfig<MovieServiceModel, MovieActivateDTO>
              .NewConfig()
              .Map(dest => dest.Image, src => src.ImageUrl);

            TypeAdapterConfig<MovieServiceModel, MovieArciveDTO>
              .NewConfig()
              .Map(dest => dest.Image, src => src.ImageUrl);

            TypeAdapterConfig<Movie, MovieServiceModel>
               .NewConfig()
               .TwoWays();

            TypeAdapterConfig<UpdateMovieRequest, MovieServiceModel>
                 .NewConfig()
                 .Map(dest => dest.ImageUrl, src => src.Image);

        }
    }
}
