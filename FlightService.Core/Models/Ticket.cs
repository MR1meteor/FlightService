namespace FlightService.Core.Models
{
    public class Ticket
    {
        public long OrderNumber { get; set; }
        public DateTime OrderTime { get; set; }
        public string DeparturePoint { get; set; }
        public string ArrivalPoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string Provider { get; set; }
        
        public IEnumerable<Passenger> Passengers { get; set; } = new List<Passenger>();
    }
}
