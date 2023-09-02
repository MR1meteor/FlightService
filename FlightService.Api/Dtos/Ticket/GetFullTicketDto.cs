using FlightService.Api.Dtos.Passenger;

namespace FlightService.Api.Dtos.Ticket
{
    public class GetFullTicketDto : GetTicketDto
    {
        public IEnumerable<GetPassengerWithDocumentsDto> Passengers { get; set; }
    }
}
