using FlightService.Api.Dtos.Document;

namespace FlightService.Api.Dtos.Passenger
{
    public class GetPassengerWithDocumentsDto : GetPassengerDto
    {
        public IEnumerable<GetDocumentDto> Documents { get; set; }
    }
}
