using System.ComponentModel.DataAnnotations;

namespace FlightService.Api.Dtos.Ticket
{
    public class UpdateTicketDto
    {
        [Required]
        public long OrderNumber { get; set; }
        [Required]
        public DateTime OrderTime { get; set; }
        [Required]
        public string DeparturePoint { get; set; }
        [Required]
        public string ArrivalPoint { get; set; }
        [Required]
        public DateTime DepartureTime { get; set; }
        [Required]
        public DateTime ArrivalTime { get; set; }
        [Required]
        public string Provider { get; set; }
    }
}
