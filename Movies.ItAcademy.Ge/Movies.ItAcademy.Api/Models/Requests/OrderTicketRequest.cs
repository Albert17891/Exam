namespace Movies.ItAcademy.Api.Models.Requests
{
    public class OrderTicketRequest
    {
        public int MovieId { get; set; }
        public bool IsBooked { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsAcquired { get; set; }
    }
}
