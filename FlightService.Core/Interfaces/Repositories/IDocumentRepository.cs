using FlightService.Core.Models;

namespace FlightService.Core.Interfaces.Repositories
{
    public interface IDocumentRepository
    {
        Task<IEnumerable<Document>> GetAllByPassenger(long passengerId);
        Task<Document> Update(Document document);
        Task Delete(long documentId);

        Task<bool> ExistsById(long documentId);
        Task<bool> ExistsByData(Document document);
    }
}
