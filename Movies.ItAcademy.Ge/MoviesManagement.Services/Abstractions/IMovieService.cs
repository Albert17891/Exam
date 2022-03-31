using MoviesManagement.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesManagement.Services.Abstractions
{
    public interface IMovieService
    {
        Task<List<MovieServiceModel>> GetAllAsync();
        Task<List<MovieServiceModel>> GetActiveAllAsync();
        Task<List<MovieServiceModel>> GetNotActiveAllAsync();
        Task<List<MovieServiceModel>> GetArciveAsync();
        Task<MovieServiceModel> GetByIdAsync(int Id);
        Task<int> CreateAsync(MovieServiceModel movie);
        Task UpdateAsync(MovieServiceModel movie);
        Task DeleteAsync(int Id);
    }
}
