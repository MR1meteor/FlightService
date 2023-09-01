namespace FlightService.Core.Models
{
    public class Document
    {
        public long Id { get; set; }
        
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }

        public long PassengerId { get; set; }
    }
}
