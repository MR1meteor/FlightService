namespace FlightService.Core.Models
{
    public class ReportElement
    {
        public DateTime OrderTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public long OrderNumber { get; set; }
        public string DeparturePoint { get; set; }
        public string ArrivalPoint { get; set; }
        public bool IsCompleted { get; set; }
    }
}
