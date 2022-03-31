using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoviesManagement.Data;
using MoviesManagement.Data.EF.Repository;
using MoviesManagement.PersistanceDB.Context;

namespace Movies.ItAcademy.MVC.Infastructure.Extensions
{
    public static class RepositoryExtension
    {
        public static void AddRepoService(this IServiceCollection service)
        {
            service.AddScoped<IMovieRepository, MovieRepository>();
            service.AddScoped<ITicketRepository, TicketRepository>();
            service.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            service.AddScoped<DbContext, MovieContext>();

        }
    }
}
