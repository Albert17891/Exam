using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movies.ItAcademy.MVC.Models;
using Movies.ItAcademy.MVC.Models.DTO;
using Movies.ItAcademy.MVC.Models.SessionModel;
using MoviesManagement.Domain.Models.UserIdentiy;
using MoviesManagement.Services.Abstractions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.ItAcademy.MVC.Controllers
{
    public class MovieController : Controller
    {
        private readonly ILogger<MovieController> _logger;
        private readonly IMovieService _service;
        private readonly SignInManager<AppUser> _signinManager;
        public MovieController(ILogger<MovieController> logger, IMovieService service, SignInManager<AppUser> signInManager)
        {
            _logger = logger;
            _service = service;
            _signinManager = signInManager;

        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var movies = await _service.GetActiveAllAsync();
                if (movies == null)
                    return View("Not Found");

                return View(movies.Adapt<List<MovieDTO>>());
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Failed in Movie Index ");
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

                if (_signinManager.IsSignedIn(User))
                {
                    var session = HttpContext.Session.GetString("Order");
                    if (session != null)
                    {
                        var action = JsonConvert.DeserializeObject<SessionResult>(session);

                        if (action.Name == "დაჯავშნა")
                        {

                            TempData["Booked"] = action.Id;
                            HttpContext.Session.Clear();
                            return await Order(action.Name, new MovieDTO { Id = action.Id });
                        }
                        TempData["Acquired"] = action.Id;
                        HttpContext.Session.Clear();
                        return await Order(action.Name, new MovieDTO { Id = action.Id });
                    }
                }

                return View(movies.Adapt<MovieDTO>());
            }
            catch (System.Exception ex)
            {

                _logger.LogError(ex, "Failed in Movie Details ");
                throw;
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { StatusCode = HttpContext.Response.StatusCode });
        }




        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Order(string button, MovieDTO movie)
        {
            try
            {
                if (!_signinManager.IsSignedIn(User))
                {
                    var action = new SessionResult() { Id = movie.Id, Name = button };
                    var result = JsonConvert.SerializeObject(action);
                    HttpContext.Session.SetString("Order", result);

                }


                if (button == "დაჯავშნა")
                {

                    TempData["Booked"] = movie.Id;
                    return RedirectToAction("Booked", "Ticket");

                }
                else if (button == "გაუქმება")
                {
                    TempData["Canceled"] = movie.Id;
                    return RedirectToAction("Canceled", "Ticket");
                }
                TempData["Acquired"] = movie.Id;
                return RedirectToAction("Acquired", "Ticket");
            }
            catch (System.Exception ex)
            {

                _logger.LogError(ex, "Failed in Order Method");
                throw;
            }



        }
    }
}
