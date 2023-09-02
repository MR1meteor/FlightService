namespace FlightService.Api.Dtos.Document
{
    public class GetDocumentDto
    {
        public long Id { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
    }
}
