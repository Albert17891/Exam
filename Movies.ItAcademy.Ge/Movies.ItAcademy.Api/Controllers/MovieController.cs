using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movies.ItAcademy.Api.Models.DTO;
using MoviesManagement.Services.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.ItAcademy.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _service;
        private readonly ILogger<MovieController> _logger;


        public MovieController(IMovieService service, ILogger<MovieController> logger)
        {
            _service = service;
            _logger = logger;

        }
        //Get:Movie/GetAllMovie

        [HttpGet]
        [Route("GetAllMovie")]
        public async Task<ActionResult<List<MovieDTO>>> GetAllMovie()
        {
            try
            {
                var movies = await _service.GetAllAsync();

                return Ok(movies.Adapt<List<MovieDTO>>());
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Failed in GetAllAsync");
                throw;
            }

        }

        //Get:Movie/1

        [HttpGet("{Id}")]
        public async Task<ActionResult<MovieDTO>> GetMovieById(int Id)
        {
            try
            {
                var movie = await _service.GetByIdAsync(Id);

                return Ok(movie.Adapt<MovieDTO>());
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Failed in GetMovieById");
                throw;
            }

        }

    }
}
