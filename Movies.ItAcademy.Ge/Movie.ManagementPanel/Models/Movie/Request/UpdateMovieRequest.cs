using System;
using System.ComponentModel.DataAnnotations;

namespace Movies.ManagementPanel.Models.Movie.Request
{
    public class UpdateMovieRequest
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Actors { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }
        [Required]
        [DataType(DataType.Duration)]
        public int Duration { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Story { get; set; }
        [Required]
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }
    }
}
