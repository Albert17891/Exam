using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoviesManagement.Services.Abstractions;
using System.Threading.Tasks;

namespace Movies.ItAcademy.MVC.Controllers
{
    [Authorize(Roles = "User")]
    [Route("Ticket")]
    public class TicketController : Controller
    {
        private readonly ILogger<TicketController> _logger;
        private readonly ITicketService _service;


        public TicketController(ILogger<TicketController> logger, ITicketService service)
        {
            _logger = logger;
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }




        [HttpGet]
        [Route("Booked")]
        public async Task<IActionResult> Booked()
        {
            try
            {
                var Id = (int)TempData["Booked"];

                TempData.Clear();

                await _service.BookedAsync(Id, User.Identity.Name);
                return RedirectToAction("Details", "Movie", new { Id = Id });
            }
            catch (System.Exception ex)
            {

                _logger.LogError(ex, "Booked Failed");
            }

            return RedirectToAction("Index", "Movie");
        }


        [HttpGet]
        [Route("Canceled")]
        public async Task<IActionResult> Canceled()
        {
            try
            {
                var Id = (int)TempData["Canceled"];
                TempData.Clear();
                await _service.CanceledAsync(Id, User.Identity.Name);
                return RedirectToAction("Details", "Movie", new { Id = Id });
            }
            catch (System.Exception ex)
            {

                _logger.LogError(ex, "Canceled Failed");
                throw;
            }

        }

        [HttpGet]
        [Route("Acquired")]
        public async Task<IActionResult> Acquired()
        {
            try
            {
                var Id = (int)TempData["Acquired"];
                TempData.Clear();
                await _service.AquiredAsync(Id, User.Identity.Name);
                return RedirectToAction("Details", "Movie", new { Id = Id });
            }
            catch (System.Exception ex)
            {

                _logger.LogError(ex, "Aquired Failed");
                throw;
            }

        }


        [HttpGet]
        [Route("CheckBooked")]
        [AllowAnonymous]
        public async Task<IActionResult> CheckBooked()
        {
            try
            {
                var result = await _service.CheckBookedService();
                return Ok(result);
            }
            catch (System.Exception ex)
            {

                _logger.LogError(ex, "Failed CheckBooked");
            }

            return BadRequest();

        }

    }
}
