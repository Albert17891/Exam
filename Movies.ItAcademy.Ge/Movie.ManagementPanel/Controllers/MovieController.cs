using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movies.ManagementPanel.Models.Movie.DTO;
using Movies.ManagementPanel.Models.Movie.Request;
using MoviesManagement.Services.Abstractions;
using MoviesManagement.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.ManagementPanel.Controllers
{
    [Route("Movie")]
    [Authorize(Roles = "Moderator")]
    public class MovieController : Controller
    {
        private readonly ILogger<MovieController> _logger;
        private readonly IMovieService _service;

        public MovieController(ILogger<MovieController> logger, IMovieService service)
        {
            _logger = logger;
            _service = service;
        }



        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var movies = await _service.GetActiveAllAsync();
                if (movies == null)
                    return View("Not Found");

                var res = movies.Adapt<List<MovieDTO>>();

                return View(res);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Failed in Index action Movie Controller");
                throw;
            }

        }

        [HttpGet("Id")]
        public async Task<IActionResult> Details(int Id)
        {
            try
            {
                var movies = await _service.GetByIdAsync(Id);
                if (movies == null)
                    return View("Not Found");

                return View(movies.Adapt<MovieDTO>());
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Failed in Details action Movie Controller");
                throw;
            }

        }

        [HttpGet]
        [Route("CreateMovie")]
        public IActionResult CreateMovie()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [Route("CreateMovie")]
        public async Task<IActionResult> CreateMovie(CreateMovieRequest createMovie)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                var movieId = await _service.CreateAsync(createMovie.Adapt<MovieServiceModel>());
                return RedirectToAction("Details", new { Id = movieId });
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Failed in CreateMovie action Movie Controller");
                throw;
            }


        }

        [HttpGet("{Id}")]
        [Route("UpdateMovie")]
        public async Task<IActionResult> UpdateMovie(int Id)
        {
            try
            {
                var movie = await _service.GetByIdAsync(Id);
                return View(movie.Adapt<UpdateMovieRequest>());
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Failed in UpdateMovie action Movie Controller");
                throw;
            }

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [Route("UpdateMovie")]
        public async Task<IActionResult> UpdateMovie(UpdateMovieRequest updateMovie)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                await _service.UpdateAsync(updateMovie.Adapt<MovieServiceModel>());
                return RedirectToAction("Details", new { Id = updateMovie.Id });
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Failed in UpdateMovie action Movie Controller(Post)");
                throw;
            }

        }

        [HttpDelete("{Id}")]
        [Route("DeleteMovie")]
        public async Task<IActionResult> DeleteMovie(int Id)
        {
            try
            {
                await _service.DeleteAsync(Id);

                return RedirectToAction("Index");
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Failed in DeleteMovie action Movie Controller");
                throw;
            }


        }



    }
}
