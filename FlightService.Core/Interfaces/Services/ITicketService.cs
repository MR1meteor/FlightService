using FlightService.Core.Models;

namespace FlightService.Core.Interfaces.Services
{
    public interface ITicketService
    {
        Task<IEnumerable<Ticket>> GetTickets();
        Task<Ticket> GetTicketByOrderNumber(long ticketOrderNumber);
        Task<Ticket> UpdateTicket(Ticket ticket);
        Task DeleteTicket(long ticketOrderNumber);
    }
}
