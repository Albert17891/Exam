using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movies.ItAcademy.Api.Models.Requests;
using MoviesManagement.Services.Abstractions;
using MoviesManagement.Services.Models;
using System.Threading.Tasks;

namespace Movies.ItAcademy.Api.Controllers
{
    [Authorize(Roles = "User")]
    [Route("[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _service;
        private readonly ILogger<TicketController> _logger;

        public TicketController(ITicketService service, ILogger<TicketController> logger)
        {
            _service = service;
            _logger = logger;
        }




        [HttpPost]
        [Route("BookedTicket")]
        public async Task<IActionResult> BookedTicket(OrderTicketRequest tickedBooked)
        {
            try
            {
                if (tickedBooked == null)
                    return BadRequest();

                var ticket = tickedBooked.Adapt<TicketServiceModel>();
                ticket.UserName = User.Identity.Name;

                await _service.OrderAsync(ticket);

                return Ok();
            }
            catch (System.Exception ex)
            {

                _logger.LogError(ex, "Failed in BookedTicket");
                throw;
            }

        }
        [Route("CanceledTicket")]
        [HttpPost]
        public async Task<IActionResult> CanceledTicket(OrderTicketRequest tickedCanceled)
        {
            try
            {
                if (tickedCanceled == null)
                    return BadRequest();

                var ticket = tickedCanceled.Adapt<TicketServiceModel>();
                ticket.UserName = User.Identity.Name;

                await _service.OrderAsync(ticket);

                return Ok();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Failed in CanceledTicket");
                throw;
            }

        }

        [Route("AcquiredTicket")]
        [HttpPost]
        public async Task<IActionResult> AcquiredTicket(OrderTicketRequest tickedAcquired)
        {
            try
            {
                if (tickedAcquired == null)
                    return BadRequest();

                var ticket = tickedAcquired.Adapt<TicketServiceModel>();
                ticket.UserName = User.Identity.Name;

                await _service.OrderAsync(ticket);

                return Ok();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Failed in AcquiredTicket");
                throw;
            }

        }
    }
}
