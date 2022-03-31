using MoviesManagement.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesManagement.Services.Abstractions
{
    public interface ITicketService
    {
        Task OrderAsync(TicketServiceModel ticket);
        Task<TicketServiceModel> GetTicketByMovie(string Name, int Id);
        Task<List<TicketServiceModel>> GetAllTickets(string name);
        Task<TicketServiceModel> GetTicket(int Id);
        Task<TicketServiceModel> GetTicketByUserName(string username);
        Task Remove(int Id);
        Task Update(TicketServiceModel ticket);
        Task<int> TicketCountAsync(int movieId);
        Task BookedAsync(int Id, string name);
        Task CanceledAsync(int Id, string name);
        Task AquiredAsync(int Id, string name);
        Task<bool> CheckBookedService();
    }
}
