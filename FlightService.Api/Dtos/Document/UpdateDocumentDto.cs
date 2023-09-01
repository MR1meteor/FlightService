using System.ComponentModel.DataAnnotations;

namespace FlightService.Api.Dtos.Document
{
    public class UpdateDocumentDto
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string DocumentType { get; set; }
        [Required]
        public string DocumentNumber { get; set; }
    }
}
