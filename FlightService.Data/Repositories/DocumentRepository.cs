using Dapper;
using FlightService.Core.Interfaces.Repositories;
using FlightService.Core.Models;
using FlightService.Data.Data;

namespace FlightService.Data.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private const string TABLE_NAME = "public.\"Documents\"";
        private readonly DapperContext _context;

        public DocumentRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Document>> GetAllByPassenger(long passengerId)
        {
            var query = $"SELECT * FROM {TABLE_NAME} WHERE \"PassengerId\" = @passengerId";

            var queryArgs = new { PassengerId = passengerId };

            using (var connection = _context.CreateConnection())
            {
                var documents = await connection.QueryAsync<Document>(query, queryArgs);
                return documents.ToList();
            }
        }

        public async Task Update(Document document)
        {
            var query = $@"UPDATE {TABLE_NAME} 
                        SET ""DocumentType"" = @documentType, ""DocumentNumber"" = @documentNumber
                        WHERE ""Id"" = @id";
                        //RETURNING *";

            var queryArgs = new
            {
                DocumentType = document.DocumentType,
                DocumentNumber = document.DocumentNumber,
                Id = document.Id
            };

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, queryArgs);
            }
        }
        
        public async Task Delete(long documentId)
        {
            var query = $"DELETE FROM {TABLE_NAME} WHERE \"Id\" = @id";

            var queryArgs = new { Id = documentId };

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, queryArgs);
            }
        }

        public async Task<bool> ExistsById(long documentId)
        {
            var query = $@"SELECT EXISTS(SELECT {TABLE_NAME}.""Id"" FROM {TABLE_NAME} 
                        WHERE {TABLE_NAME}.""Id"" = @id)";

            var queryArgs = new { Id = documentId };

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<bool>(query, queryArgs);
                return result.FirstOrDefault();
            }
        }

        public async Task<bool> ExistsByData(Document document)
        {
            var query = $@"SELECT EXISTS(SELECT {TABLE_NAME}.""Id"" FROM {TABLE_NAME} 
                        WHERE {TABLE_NAME}.""DocumentType"" = @documentType AND {TABLE_NAME}.""DocumentNumber"" = @documentNumber)";

            var queryArgs = new
            {
                DocumentType = document.DocumentType,
                DocumentNumber = document.DocumentNumber
            };

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<bool>(query, queryArgs);
                return result.FirstOrDefault();
            }
        }
    }
}
