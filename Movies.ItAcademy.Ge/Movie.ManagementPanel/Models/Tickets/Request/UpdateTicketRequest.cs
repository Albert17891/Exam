namespace Movies.ManagementPanel.Models.Tickets.Request
{
    public class UpdateTicketRequest
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int TicketNumber { get; set; }
        public bool IsBooked { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsAcquired { get; set; }
        public string UserName { get; set; }
    }
}
