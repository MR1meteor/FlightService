using FlightService.Core.Exceptions;
using FlightService.Core.Interfaces.Repositories;
using FlightService.Core.Interfaces.Services;
using FlightService.Core.Models;

namespace FlightService.Services.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;

        public DocumentService(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task<IEnumerable<Document>> GetDocumentsByPassengersAsync(long passengerId)
        {
            if (passengerId <= 0)
                throw new BadRequestException("Passenger Id cannot be less than 1");

            var documents = await _documentRepository.GetAllByPassenger(passengerId);
            return documents;
        }

        public async Task UpdateDocumentAsync(Document document)
        {
            
            if (document == null)
                throw new BadRequestException("Document was null");

            if (document.Id <= 0)
                throw new BadRequestException("Document Id cannot be less than 1");

            var documentExists = await _documentRepository.ExistsById(document.Id);

            if (!documentExists)
                throw new NotFoundException($"Document with id: {document.Id} not found");

            var equalDocumentExists = await _documentRepository.ExistsByData(document);

            if (equalDocumentExists)
                throw new ConflictException($"Document with type: {document.DocumentType} and number: {document.DocumentNumber} already exists");

            await _documentRepository.Update(document);
        }
        
        public async Task DeleteDocumentAsync(long documentId)
        {
            if (documentId <= 0)
                throw new BadRequestException("Document Id cannot be less than 1");

            var documentExists = await _documentRepository.ExistsById(documentId);

            if (!documentExists)
                throw new NotFoundException($"Document with id: {documentId} not found");

            await _documentRepository.Delete(documentId);
        }
    }
}
