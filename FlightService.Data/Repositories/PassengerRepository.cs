using Dapper;
using FlightService.Core.Interfaces.Repositories;
using FlightService.Core.Models;
using FlightService.Data.Data;

namespace FlightService.Data.Repositories
{
    public class PassengerRepository : IPassengerRepository
    {
        private const string TABLE_NAME = @"public.""Passengers""";
        private const string PASSENGERS_TICKETS_TABLE_NAME = @"public.""Tickets_Passengers""";
        private readonly DapperContext _context;

        public PassengerRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Passenger>> GetAllByTicket(long ticketOrderNumber)
        {
            var query = $@"SELECT * FROM {TABLE_NAME} WHERE ""Id"" IN
                        (SELECT ""PassengerId"" FROM {PASSENGERS_TICKETS_TABLE_NAME}
                        WHERE ""OrderNumber"" = @orderNumber)";

            var queryArgs = new { OrderNumber = ticketOrderNumber };

            using (var connection = _context.CreateConnection())
            {
                var passengers = await connection.QueryAsync<Passenger>(query, queryArgs);
                return passengers.ToList();
            }
        }

        public async Task<Passenger> Update(Passenger passenger)
        {
            var query = $@"UPDATE {TABLE_NAME}
                        SET ""Name"" = @name, ""Surname"" = @surname, ""Patronymic"" = @patronymic
                        WHERE ""Id"" = @id
                        RETURNING *";

            var queryArgs = new
            {
                Name = passenger.Name,
                Surname = passenger.Surname,
                Patronymic = passenger.Patronymic,
                Id = passenger.Id
            };

            using (var connection = _context.CreateConnection())
            {
                var updatedPassenger = await connection.QueryAsync<Passenger>(query, queryArgs);
                return updatedPassenger.FirstOrDefault();
            }
        }
        
        public async Task Delete(long passengerId)
        {
            var query = $@"DELETE FROM {TABLE_NAME} WHERE ""Id"" = @id";

            var queryArgs = new { Id = passengerId };

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, queryArgs);
            }
        }

        public async Task<bool> ExistsById(long passengerId)
        {
            var query = $@"SELECT EXISTS(SELECT {TABLE_NAME}.""Id"" FROM {TABLE_NAME} 
                        WHERE {TABLE_NAME}.""Id"" = @id)";

            var queryArgs = new { Id = passengerId };

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<bool>(query, queryArgs);
                return result.FirstOrDefault();
            }
        }
    }
}
