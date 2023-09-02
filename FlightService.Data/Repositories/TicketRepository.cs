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
        private const string PASSENGERS_TICKETS_TABLE_NAME = @"public.""Tickets_Passengers""";
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

        public async Task<IEnumerable<Ticket>> GetAllByPassengerInRange(long passengerId, DateTime startTime, DateTime endTime)
        {
            var query = $@"SELECT * FROM {TABLE_NAME} WHERE ""OrderNumber"" IN
                        (SELECT ""OrderNumber"" FROM {PASSENGERS_TICKETS_TABLE_NAME}
                        WHERE ""PassengerId"" = @passengerId) 
                        AND (""OrderTime"" <= @startTime AND ""ArrivalTime"" BETWEEN @startTime AND @endTime OR
                        ""OrderTime"" BETWEEN @startTime AND @endTime)";

            var queryArgs = new 
            {
                PassengerId = passengerId,
                StartTime = startTime,
                EndTime = endTime
            };

            using (var connection = _context.CreateConnection())
            {
                var tickets = await connection.QueryAsync<Ticket>(query, queryArgs);
                return tickets.ToList();
            }
        }

        public async Task<Ticket> GetById(long ticketOrderNumber)
        {
            var query = $@"SELECT * FROM {TABLE_NAME} WHERE ""OrderNumber"" = @orderNumber";

            var queryArgs = new { OrderNumber = ticketOrderNumber };

            using (var connection = _context.CreateConnection())
            {
                var ticket = await connection.QueryAsync<Ticket>(query, queryArgs);
                return ticket.FirstOrDefault();
            }
        }

        public async Task<Ticket> Update(Ticket ticket)
        {
            var query = $@"UPDATE {TABLE_NAME} 
                        SET ""OrderTime"" = @orderTime, ""DeparturePoint"" = @departurePoint,
                        ""ArrivalPoint"" = @arrivalPoint, ""DepartureTime"" = @departureTime,
                        ""ArrivalTime"" = @arrivalTime, ""Provider"" = @provider
                        WHERE ""OrderNumber"" = @orderNumber
                        RETURNING *";

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
                var updatedTicket = await connection.QueryAsync<Ticket>(query, queryArgs);
                return updatedTicket.FirstOrDefault();
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
