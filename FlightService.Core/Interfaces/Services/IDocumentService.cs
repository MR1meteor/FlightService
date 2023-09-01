using FlightService.Core.Models;

namespace FlightService.Core.Interfaces.Services
{
    public interface IDocumentService
    {
        Task<IEnumerable<Document>> GetDocumentsByPassengersAsync(long passengerId);
        Task UpdateDocumentAsync(Document document);
        Task DeleteDocumentAsync(long documentId);
    }
}
