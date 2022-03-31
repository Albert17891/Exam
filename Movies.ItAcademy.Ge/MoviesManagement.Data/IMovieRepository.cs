using MoviesManagement.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesManagement.Data
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllMoviesAsync();
        Task<List<Movie>> GetActiveMovieAsync();
        Task<Movie> GetMovieByIdAsync(int Id);
        Task<List<Movie>> GetNotActiveMovieAsync();
        Task<List<Movie>> GetStartTimeOneHour();
        Task<List<Movie>> GetArciveMovie();
        Task<int> CreateMovieAsync(Movie movie);
        Task UpdateMovieAsync(Movie movie);
        Task DeleteMovieAsync(int Id);
    }
}
