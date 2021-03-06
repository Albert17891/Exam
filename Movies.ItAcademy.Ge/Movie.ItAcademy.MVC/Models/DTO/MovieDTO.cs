using MoviesManagement.Services.Models;
using System;
using System.Collections.Generic;

namespace Movies.ItAcademy.MVC.Models.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public string Story { get; set; }
        public string Image { get; set; }
        public List<TicketServiceModel> Tickets { get; set; }
    }
}

