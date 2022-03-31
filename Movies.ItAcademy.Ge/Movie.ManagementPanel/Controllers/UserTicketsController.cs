using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movies.ManagementPanel.Models.Tickets;
using Movies.ManagementPanel.Models.Tickets.Request;
using Movies.ManagementPanel.Models.User;
using MoviesManagement.Domain.Models.UserIdentiy;
using MoviesManagement.Services.Abstractions;
using MoviesManagement.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.ManagementPanel.Controllers
{
    [Authorize(Roles = "Moderator")]
    [Route("UserTickets")]
    public class UserTicketsController : Controller
    {
        private readonly UserManager<AppUser> _userManger;
        private readonly ITicketService _service;
        private readonly ILogger<UserTicketsController> _logger;

        public UserTicketsController(UserManager<AppUser> userManager, ITicketService service, ILogger<UserTicketsController> logger)
        {
            _userManger = userManager;
            _service = service;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManger.GetUsersInRoleAsync("User");
            return View(users.Adapt<List<UserModel>>());
        }

        [HttpGet("{name}")]
        [Route("Tickets")]
        public async Task<IActionResult> Tickets(string name)
        {
            try
            {
                var tickets = await _service.GetAllTickets(name);
                return View(tickets.Adapt<List<UserTickets>>());
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Failed  Tickets action in UserTickets controller");
                throw;
            }

        }

        [HttpGet("{Id}")]
        [Route("DeleteTicket")]
        public async Task<IActionResult> DeleteTicket(int Id)
        {
            try
            {
                await _service.Remove(Id);
                return RedirectToAction("Index");
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Failed  DeleteTickets action in UserTickets controller");

                throw;
            }

        }

        [HttpGet/*("Id")*/]
        [Route("UpdateTicket")]
        public async Task<IActionResult> UpdateTicket(int Id)
        {
            try
            {
                var ticket = await _service.GetTicket(Id);
                return View(ticket.Adapt<UpdateTicketRequest>());
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Failed  UpdateTickets action in UserTickets controller");
                throw;
            }

        }

        [HttpPost]
        [Route("UpdateTicket")]
        public async Task<IActionResult> UpdateTicket(UpdateTicketRequest updateTicket)
        {
            try
            {
                await _service.Update(updateTicket.Adapt<TicketServiceModel>());
                return RedirectToAction("Tickets", new { name = updateTicket.UserName });
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Failed  UpdateTickets action in UserTickets controller(post)");
                throw;
            }

        }
    }
}
