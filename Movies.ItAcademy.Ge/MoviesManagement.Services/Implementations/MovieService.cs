using Mapster;
using MoviesManagement.Data;
using MoviesManagement.Domain.Models;
using MoviesManagement.Services.Abstractions;
using MoviesManagement.Services.Exceptions;
using MoviesManagement.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesManagement.Services.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;

        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<MovieServiceModel>> GetActiveAllAsync()
        {
            var movies = await _repository.GetActiveMovieAsync();
            if (movies == null)
                throw new ObjectNotFoundException("Not Found");

            return movies.Adapt<List<MovieServiceModel>>();
        }


        public async Task<List<MovieServiceModel>> GetNotActiveAllAsync()
        {
            var movies = await _repository.GetNotActiveMovieAsync();

            return movies.Adapt<List<MovieServiceModel>>();
        }


        public async Task<List<MovieServiceModel>> GetAllAsync()
        {
            var movies = await _repository.GetAllMoviesAsync();
            if (movies == null)
                throw new ObjectNotFoundException("Not Found");

            return movies.Adapt<List<MovieServiceModel>>();
        }

        public async Task<List<MovieServiceModel>> GetArciveAsync()
        {
            var movies = await _repository.GetActiveMovieAsync();
            if (movies == null)
                throw new ObjectNotFoundException("Not Found");

            return movies.Adapt<List<MovieServiceModel>>();
        }
        public async Task<MovieServiceModel> GetByIdAsync(int Id)
        {
            var movie = await _repository.GetMovieByIdAsync(Id);
            if (movie == null)
                throw new ObjectWithThisIdNotFound("Not Found");

            var movieService = movie.Adapt<MovieServiceModel>();

            return movieService;
        }
        public async Task<int> CreateAsync(MovieServiceModel movie)
        {
            var movieId = await _repository.CreateMovieAsync(movie.Adapt<Movie>());
            return movieId;

        }

        public async Task DeleteAsync(int Id)
        {
            await _repository.DeleteMovieAsync(Id);
        }

        public async Task UpdateAsync(MovieServiceModel movie)
        {
            await _repository.UpdateMovieAsync(movie.Adapt<Movie>());
        }


    }
}
