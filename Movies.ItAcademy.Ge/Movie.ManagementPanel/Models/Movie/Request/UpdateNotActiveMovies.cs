using System;

namespace Movies.ManagementPanel.Models.Movie.Request
{
    public class UpdateNotActiveMovies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public string Story { get; set; }
        public bool Archive { get; set; }
        public string Image { get; set; }
    }
}
