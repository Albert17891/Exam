using MoviesManagement.Services.Models;
using System;
using System.Collections.Generic;

namespace Movies.ItAcademy.Api.Models.DTO
{
    public class MovieDTO
    {
        public string Name { get; set; }
        public string Genre { get; set; }

        public string Director { get; set; }

        public string Actors { get; set; }

        public DateTime StartTime { get; set; }

        public int Duration { get; set; }

        public string Story { get; set; }

        public string ImageUrl { get; set; }

        public List<TicketServiceModel> Tickets { get; set; }
    }
}
