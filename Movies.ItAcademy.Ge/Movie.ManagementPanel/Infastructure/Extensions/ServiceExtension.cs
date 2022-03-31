using Microsoft.Extensions.DependencyInjection;
using MoviesManagement.Services.Abstractions;
using MoviesManagement.Services.Implementations;

namespace Movies.ManagementPanel.Infastructure.Extensions
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection service)
        {
            service.AddScoped<IMovieService, MovieService>();
            service.AddScoped<ITicketService, TicketService>();
            service.AddRepoService();
        }
    }
}
