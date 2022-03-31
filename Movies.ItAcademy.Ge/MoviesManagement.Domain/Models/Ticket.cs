namespace MoviesManagement.Domain.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public bool IsBooked { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsAcquired { get; set; }
        public string UserName { get; set; }
        public Movie Movie { get; set; }
    }
}
