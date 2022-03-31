using Microsoft.EntityFrameworkCore;
using MoviesManagement.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesManagement.Data.EF.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly IBaseRepository<Ticket> _repository;

        public TicketRepository(IBaseRepository<Ticket> repository)
        {
            _repository = repository;
        }

        //Gets All Tickets
        public Task<List<Ticket>> GetAllTicket(string username)
        {
            return _repository.Table.Where(x => x.UserName == username).ToListAsync();
        }
        //Remove Ticket By Id
        public async Task Remove(int Id)
        {
            var ticket = await _repository.Table.SingleOrDefaultAsync(x => x.Id == Id);
            await _repository.DeleteEntityAsync(ticket);

        }
        //Update Ticket By Id
        public async Task Update(Ticket ticket)
        {
            await _repository.UpdateEntityAsync(ticket);
        }
        //Will check up If the ticket exists, updates it, if doesn't exist, creates it
        public async Task OrderMovieAsync(Ticket ticket)
        {

            if (await Exist(ticket.MovieId, ticket.UserName))
            {
                var result = await GetTicketByUserNameAndId(ticket.UserName, ticket.MovieId);
                ticket.Id = result.Id;

                await _repository.UpdateEntityAsync(ticket);
            }
            else
            {

                await _repository.CreateEntityAsync(ticket);
            }
        }
        //Cheks if ticket Exist 
        public async Task<bool> Exist(int movieId, string name)
        {
            return await _repository.Table.AnyAsync(x => x.MovieId == movieId && x.UserName == name);

        }
        //Gets ticket By Id
        public async Task<Ticket> GetTicketById(int Id)
        {
            return await _repository.GetEntityByIdAsync(Id);
        }
        //Gets Ticket By UserName
        public async Task<Ticket> GetTicketByUserName(string username)
        {
            return await _repository.TableNoTracking.SingleOrDefaultAsync(x => x.UserName == username);

        }
        //Get Ticket By User Name And Id
        public async Task<Ticket> GetTicketByUserNameAndId(string username, int Id)
        {
            return await _repository.TableNoTracking.Where(x => x.UserName == username & x.MovieId == Id).SingleOrDefaultAsync();

        }
        //Counts Aquired and Booked Ticket s
        public async Task<int> TicketCount(int movieId)
        {
            return await _repository.Table.Where(x => x.IsBooked == true || x.IsAcquired == true).CountAsync(x => x.MovieId == movieId);
        }

        //Cheked if the ticket Booked
        public async Task<List<Ticket>> CheckBooked(int movieId)
        {
            return await _repository.TableNoTracking.Where(x => x.IsBooked == true && x.MovieId == movieId).ToListAsync();
        }
    }
}
