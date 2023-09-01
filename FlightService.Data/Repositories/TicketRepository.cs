using Dapper;
using FlightService.Core.Interfaces.Repositories;
using FlightService.Core.Models;
using FlightService.Data.Data;
using System.Reflection.Metadata;

namespace FlightService.Data.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private const string TABLE_NAME = @"public.""Tickets""";
        private readonly DapperContext _context;

        public TicketRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ticket>> GetAll()
        {
            var query = $@"SELECT * FROM {TABLE_NAME}";

            using (var connection = _context.CreateConnection())
            {
                var tickets = await connection.QueryAsync<Ticket>(query);
                return tickets.ToList();
            }
        }

        public async Task<Ticket> GetById(long ticketOrderNumber)
        {
            var query = $@"SELECT * FROM {TABLE_NAME} WHERE ""OrderNumber"" = @orderNumber";
            //var query = $@"SELECT * FROM {TABLE_NAME}
            //            LEFT JOIN {PASSENGERS_TABLE_NAME} ON {PASSENGERS_TABLE_NAME}.""Id"" IN
            //            (SELECT ""PassengerId"" FROM {PASSENGERS_TICKETS_TABLE_NAME} WHERE ""OrderNumber"" = @orderNumber)
            //            LEFT JOIN {DOCUMENTS_TABLE_NAME} ON {DOCUMENTS_TABLE_NAME}.""Id"" = ""PassengerId""";

            var queryArgs = new { OrderNumber = ticketOrderNumber };

            using (var connection = _context.CreateConnection())
            {
                var ticket = await connection.QueryAsync<Ticket>(query, queryArgs);
                return ticket.FirstOrDefault();
            }
        }

        public async Task Update(Ticket ticket)
        {
            var query = $@"UPDATE {TABLE_NAME} 
                        SET ""OrderTime"" = @orderTime, ""DeparturePoint"" = @departurePoint,
                        ""ArrivalPoint"" = @arrivalPoint, ""DepartureTime"" = @departureTime,
                        ""ArrivalTime"" = @arrivalTime, ""Provider"" = @provider
                        WHERE ""OrderNumber"" = @orderNumber";

            var queryArgs = new
            {
                OrderNumber = ticket.OrderNumber,
                OrderTime = ticket.OrderTime,
                DeparturePoint = ticket.DeparturePoint,
                ArrivalPoint = ticket.ArrivalPoint,
                DepartureTime = ticket.DepartureTime,
                ArrivalTime = ticket.ArrivalTime,
                Provider = ticket.Provider
            };

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, queryArgs);
            }
        }
        
        public async Task Delete(long ticketOrderNumber)
        {
            var query = $@"DELETE FROM {TABLE_NAME} WHERE ""OrderNumber"" = @orderNumber";

            var queryArgs = new { OrderNumber = ticketOrderNumber };

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, queryArgs);
            }
        }

        public async Task<bool> ExistsByOrderNumber(long ticketOrderNumber)
        {
            var query = $@"SELECT EXISTS(SELECT {TABLE_NAME}.""OrderNumber"" FROM {TABLE_NAME} 
                        WHERE {TABLE_NAME}.""OrderNumber"" = @orderNumber)";

            var queryArgs = new { OrderNumber = ticketOrderNumber };

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<bool>(query, queryArgs);
                return result.FirstOrDefault();
            }
        }
    }
}
