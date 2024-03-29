﻿using System;
using System.Collections.Generic;

namespace MoviesManagement.Domain.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public string Story { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public bool Archive { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
