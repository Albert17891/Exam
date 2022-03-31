using Microsoft.EntityFrameworkCore;
using MoviesManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesManagement.Data.EF.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IBaseRepository<Movie> _repository;

        public MovieRepository(IBaseRepository<Movie> repository)
        {
            _repository = repository;
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _repository.Table.ToListAsync();
        }

        //Gets All Active movies In Db
        public async Task<List<Movie>> GetActiveMovieAsync()
        {
            return await _repository.Table.Where(x => x.IsActive == true && x.Archive == false).ToListAsync();
        }

        //Gets All Not Active Movies In Db
        public async Task<List<Movie>> GetNotActiveMovieAsync()
        {
            return await _repository.TableNoTracking.Where(x => x.IsActive == false && x.Archive == false && x.StartTime < DateTime.Now).ToListAsync();
        }

        //Gets Movie By Id
        public async Task<Movie> GetMovieByIdAsync(int Id)
        {
            return await _repository.Table.SingleOrDefaultAsync(x => x.Id == Id);
        }

        //Create new Movie
        public async Task<int> CreateMovieAsync(Movie movie)
        {
            await _repository.CreateEntityAsync(movie);
            return movie.Id;
        }

        //Delete Movie By Id
        public async Task DeleteMovieAsync(int Id)
        {
            var movie = await _repository.GetEntityByIdAsync(Id);

            await _repository.DeleteEntityAsync(movie);
        }

        //Update Movie By Id
        public async Task UpdateMovieAsync(Movie movie)
        {
            await _repository.UpdateEntityAsync(movie);
        }

        //Gets Movie which Startime is less one hour
        public async Task<List<Movie>> GetStartTimeOneHour()
        {
            return await _repository.Table.Where(x => x.StartTime < DateTime.Now.AddHours(1)).ToListAsync();
        }

        //Gets Arcive Movies
        public async Task<List<Movie>> GetArciveMovie()
        {
            return await _repository.Table.Where(x => x.Archive == true).ToListAsync();
        }
    }
}
