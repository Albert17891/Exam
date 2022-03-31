using Mapster;
using MoviesManagement.Data;
using MoviesManagement.Domain.Models;
using MoviesManagement.Services.Abstractions;
using MoviesManagement.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesManagement.Services.Implementations
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _repository;
        private readonly IMovieRepository _movieRepository;

        public TicketService(ITicketRepository repository, IMovieRepository movieRepository)
        {
            _repository = repository;
            _movieRepository = movieRepository;
        }
        public async Task OrderAsync(TicketServiceModel ticket)
        {
            await _repository.OrderMovieAsync(ticket.Adapt<Ticket>());
        }

        public async Task<TicketServiceModel> GetTicket(int Id)
        {
            var ticket = await _repository.GetTicketById(Id);
            return ticket.Adapt<TicketServiceModel>();
        }

        public async Task<TicketServiceModel> GetTicketByUserName(string username)
        {
            var ticket = await _repository.GetTicketByUserName(username);
            return ticket.Adapt<TicketServiceModel>();
        }

        public async Task Remove(int Id)
        {
            await _repository.Remove(Id);

        }

        public async Task Update(TicketServiceModel ticket)
        {
            await _repository.Update(ticket.Adapt<Ticket>());
        }

        public async Task<List<TicketServiceModel>> GetAllTickets(string name)
        {
            var tickets = await _repository.GetAllTicket(name);

            return tickets.Adapt<List<TicketServiceModel>>();
        }

        public async Task<TicketServiceModel> GetTicketByMovie(string Name, int Id)
        {
            var res = await _repository.GetTicketByUserNameAndId(Name, Id);
            return res.Adapt<TicketServiceModel>();
        }

        public async Task<int> TicketCountAsync(int movieId)
        {
            return await _repository.TicketCount(movieId);
        }
        // Booked Ticket
        public async Task BookedAsync(int Id, string name)
        {
            var ticket = new TicketServiceModel()
            {
                MovieId = Id,
                IsBooked = true,
                IsCanceled = false,
                UserName = name

            };
            await _repository.OrderMovieAsync(ticket.Adapt<Ticket>());
        }
        //Canceled Ticket
        public async Task CanceledAsync(int Id, string name)
        {
            var ticket = new TicketServiceModel()
            {
                MovieId = Id,
                IsBooked = false,
                IsCanceled = false,
                UserName = name

            };
            await _repository.OrderMovieAsync(ticket.Adapt<Ticket>());
        }
        //Aquired Ticket
        public async Task AquiredAsync(int Id, string name)
        {
            var ticket = new TicketServiceModel()
            {
                MovieId = Id,
                IsBooked = false,
                IsCanceled = false,
                IsAcquired = true,
                UserName = name

            };
            await _repository.OrderMovieAsync(ticket.Adapt<Ticket>());
        }

        //Checks Booked Tickets
        public async Task<bool> CheckBookedService()
        {
            var movies = await _movieRepository.GetStartTimeOneHour();
            if (movies.Count == 0)
            {
                return false;
            }
            foreach (var movie in movies)
            {
                var tickets = await _repository.CheckBooked(movie.Id);
                if (tickets == null)
                {
                    return false;
                }
                foreach (var ticket in tickets)
                {
                    ticket.IsBooked = false;
                    ticket.IsCanceled = true;
                    await _repository.Update(ticket);
                }
            }

            return true;
        }
    }
}
