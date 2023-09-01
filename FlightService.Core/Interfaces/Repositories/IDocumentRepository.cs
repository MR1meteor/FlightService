using FlightService.Core.Models;

namespace FlightService.Core.Interfaces.Repositories
{
    public interface IDocumentRepository
    {
        Task<IEnumerable<Document>> GetAllByPassengerId(long passengerId);
        Task Update(Document document);
        Task Delete(long documentId);
    }
}
