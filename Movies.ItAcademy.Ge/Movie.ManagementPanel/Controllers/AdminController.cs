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
    [Authorize(Roles = "Admin")]
    [Route("Admin")]
    public class AdminController : Controller
    {
        private readonly IMovieService _service;
        private readonly ILogger<AdminController> _logger;

        public AdminController(IMovieService service,ILogger<AdminController> logger)
        {
            _service = service;
            _logger = logger;
        }


        public async Task<IActionResult> Index()
        {
            try
            {
                var movies = await _service.GetAllAsync();
                if (movies == null)
                    return View("Not Found");

                return View(movies.Adapt<List<MovieActivateDTO>>());
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Failed in GetAllAsync");
                throw;
            }
            
        }

        [HttpGet("{Id}")]
        [Route("Activate")]
        public async Task<IActionResult> Activate(int Id)
        {
            try
            {
                var movie = await _service.GetByIdAsync(Id);
                return View(movie.Adapt<UpdateActiveRequest>());
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Failed in Activate");
                throw;
            }
            
        }

        [HttpPost]
        [Route("Activate")]
        public async Task<IActionResult> Activate(UpdateActiveRequest update)
        {
            try
            {
                await _service.UpdateAsync(update.Adapt<MovieServiceModel>());
                return RedirectToAction("Index");
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Failed in Activate (Post)");
                throw;
            }
           
        }

        [HttpGet]
        [Route("GetArciveMovie")]
        public async Task<IActionResult> GetArciveMovie()
        {
            try
            {
                var movies = await _service.GetArciveAsync();
                return View(movies.Adapt<MovieArciveDTO>());
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Failed in GetArciveMovie");
                throw;
            }
            
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("CheckActive")]
        public async Task<IActionResult> CheckActive()
        {
            try
            {
                var movies = await _service.GetNotActiveAllAsync();
                if (movies.Count==0)
                    return Ok("O Change");

                foreach (var movie in movies)
                {
                    movie.Archive = true;
                    await _service.UpdateAsync(movie);
                }

                return Ok("Arcived");
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Failed in CheckActive");
                return BadRequest(ex);
            }

        }
    }
}
