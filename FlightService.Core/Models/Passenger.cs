
namespace FlightService.Core.Models
{
    public class Passenger
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }

        public IEnumerable<Document> Documents { get; set; } = new List<Document>();
        public IEnumerable<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
