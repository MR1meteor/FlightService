namespace FlightService.Api.Dtos.Ticket
{
    public class GetTicketDto
    {
        public long OrderNumber { get; set; }
        public DateTime OrderTime { get; set; }
        public string DeparturePoint { get; set; }
        public string ArrivalPoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string Provider { get; set; }
    }
}
