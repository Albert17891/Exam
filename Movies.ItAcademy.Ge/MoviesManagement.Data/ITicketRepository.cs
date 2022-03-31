using MoviesManagement.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesManagement.Data
{
    public interface ITicketRepository
    {
        Task<List<Ticket>> GetAllTicket(string name);
        Task<Ticket> GetTicketById(int Id);
        Task<Ticket> GetTicketByUserName(string username);
        Task<Ticket> GetTicketByUserNameAndId(string username, int Id);
        Task Remove(int Id);
        Task Update(Ticket ticket);
        Task<bool> Exist(int movieId, string name);
        Task OrderMovieAsync(Ticket ticket);
        Task<int> TicketCount(int movieId);
        Task<List<Ticket>> CheckBooked(int movieId);

    }
}
